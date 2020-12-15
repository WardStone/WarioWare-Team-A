using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadioRTL
{
    namespace CeremonieDeThe
    {

        /// <summary>
        /// Riwan HERVOUET
        /// </summary>

        public class Script_TeaPotController : TimedBehaviour
        {

            //1- Initialisation des variables
            private Rigidbody2D teaPotRigidBody;
            public float teaPotSpeed;
            public Vector2 mouvementTeaPot;
            float moveHorizontal;
            float moveVertical;

            //2- Récupération du component et positionement du Tea-Pot
            public override void Start()
            {
                base.Start(); //Do not erase this line!

                gameObject.transform.Translate(0.0f, -2.0f, 0.0f);
                teaPotRigidBody = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;

            }
            private void Update()
            {
                //3.1- Déplacement du Tea-Pot

            }

            //3- FixedUpdate is called on a fixed time & déplacement du Tea-Pot
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!
                moveHorizontal = Input.GetAxis("Left_Joystick_X");

                moveVertical = Input.GetAxis("Left_Joystick_Y");

                if (moveHorizontal > 0.15f || moveVertical > 0.15f || moveHorizontal < -0.15f || moveVertical < -0.15f) //Pour éviter les micormouvement parasite
                {

                    mouvementTeaPot = new Vector2(moveHorizontal, -moveVertical);

                    teaPotRigidBody.AddForce(mouvementTeaPot * teaPotSpeed);

                }
                else //pour éviter que le Tea-Pot continue de bouger si il y a 0 input
                {
                    mouvementTeaPot = new Vector2(0.0f, 0.0f);

                    teaPotRigidBody.AddForce(mouvementTeaPot * teaPotSpeed);
                }


            }
        }
    }
}
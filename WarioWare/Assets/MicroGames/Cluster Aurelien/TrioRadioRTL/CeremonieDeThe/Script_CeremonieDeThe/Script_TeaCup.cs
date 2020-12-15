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

        public class Script_TeaCup : TimedBehaviour
        {

            //- Création des variables
            private Rigidbody2D teaCupRigidbody;
            public float teaCupSpeed;
            public Vector2 mouvementTeaCup;
            private bool isGoingLeft;

            //2- Récupération du component et positionement de la Tea Cup
            public override void Start()
            {
                base.Start(); //Do not erase this line!

                gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
                teaCupRigidbody = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            }

            //3- TimedUpdate is called once every tick (ici la vitesse varie en fonction des tics)
            public override void TimedUpdate()
            {
                
                //3.1- Un petit delay pour pas que ça commence directe
                if (Tick > 1) 
                {

                    //3.1.1- Mouvement vers la gauche
                    if (isGoingLeft == true)
                    {

                        teaCupRigidbody.velocity = new Vector2(0, 0);

                        mouvementTeaCup = new Vector2(-2, 0);

                        teaCupRigidbody.AddForce(mouvementTeaCup * teaCupSpeed);

                        isGoingLeft = false;


                    }
                    //3.1.2- Mouvement vers la droite
                    else
                    {

                        teaCupRigidbody.velocity = new Vector2(0, 0);

                        mouvementTeaCup = new Vector2(2, 0);

                        teaCupRigidbody.AddForce(mouvementTeaCup * teaCupSpeed);

                        isGoingLeft = true;

                    }

                }

            }
        }
    }
}
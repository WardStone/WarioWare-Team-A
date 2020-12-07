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

        public class Script_PouredTea : TimedBehaviour
        {

            //1- Variables
            //1.1- Collider
            private Collider2D cupCollider;
            public Collider2D waterCollider;

            //1.2- Int
            public int pouredTea;

            //1.3- Bool
            private bool isTouchingCup = false;

            //2- Récupération du component et positionement du Tea Cup
            public override void Start()
            {
                base.Start(); //Do not erase this line!

                gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
                cupCollider = gameObject.GetComponent<Collider2D>() as Collider2D;

            }

            //3- Verification des colliders
            //3.1- Verification on Enter
            private void OnTriggerEnter2D(Collider2D waterCollider)
            {

                isTouchingCup = true;

            }

            //3.2- Verification on Enter
            private void OnTriggerExit2D(Collider2D waterCollider)
            {

                isTouchingCup = false;

            }

            //4- FixedUpdate is called on a fixed time
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                //4.1- Incrementation
                if (isTouchingCup == true)
                {

                    pouredTea = pouredTea + 1;

                }
                else
                {

                    pouredTea = pouredTea + 0;

                }
            }
        }
    }
}
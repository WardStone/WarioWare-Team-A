using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace RadioRTL
{
    namespace CeremonieDeThe
    {

        /// <summary>
        /// Riwan HERVOUET
        /// </summary>

        public class Script_EndOfTheGame : TimedBehaviour
        {

            //1- Variables
            //1.1- Game Object & Collider
            public GameObject teaCup;
            public Collider2D teaPotCollider;

            //1.2- Booléennes & int
            bool cupIsFull;
            bool potIsInZone = false;
            int cupQuantity;
			int waterToVictory = 100;

            //2- Récupération des donné
            public override void Start()
            {
                base.Start(); //Do not erase this line!

                //2.1- Les données à récup
                Script_PouredTea pouredTeaScript = teaCup.GetComponent<Script_PouredTea>();
                cupQuantity = pouredTeaScript.pouredTea;

            }

            //3- Verification des colliders
            //3.1- Verification on Enter
            private void OnTriggerEnter2D(Collider2D waterCollider)
            {

                potIsInZone = true;

            }

            //3.2- Verification on Enter
            private void OnTriggerExit2D(Collider2D waterCollider)
            {

                potIsInZone = false;

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            }

            //4- TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

                //4.1- A la fin de la 8 tick
                if (Tick == 8)
                {

                    //4.1.2- Verfication des conditions
                    if ( cupQuantity <= waterToVictory && potIsInZone == true)
                    {

                        Manager.Instance.Result(true);
                        Debug.Log("victoire");

                    }else
                    {

                        Manager.Instance.Result(false);
                        Debug.Log("defaite");
                    }

                }

            }
        }
    }
}
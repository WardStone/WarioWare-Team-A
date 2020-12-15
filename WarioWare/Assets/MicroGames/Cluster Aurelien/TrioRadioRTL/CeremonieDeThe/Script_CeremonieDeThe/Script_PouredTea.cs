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

			//1.4- Les Sprites d'eau
			public SpriteRenderer firstTeaLevel;
			public SpriteRenderer secondTeaLevel;
			public SpriteRenderer thirdTeaLevel;

			//1.5- Le script pour gagner
			//public Script endOfGameScript;

            //2- Récupération du component et positionement du Tea Cup
            public override void Start()
            {
                base.Start(); //Do not erase this line!

                gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
                cupCollider = gameObject.GetComponent<Collider2D>() as Collider2D;

				//2.1- Desibling des sprites d'eau pour eviter tout bugs chelou
				this.firstTeaLevel.enabled = false;
				this.secondTeaLevel.enabled = false;
				this.thirdTeaLevel.enabled = false;

				//2.2- Récupération de la quantité d'eau necessaire pour gagné et ainsi pouvoir gérer les paliers
				//Script

            }

            //3- Verification des colliders
            //3.1- Verification on Enter
            private void OnTriggerEnter2D(Collider2D waterCollider)
            {

                isTouchingCup = true;
                //Debug.Log(isTouchingCup);

            }

            //3.2- Verification on Enter
            private void OnTriggerExit2D(Collider2D waterCollider)
            {

                isTouchingCup = false;
                //Debug.Log(isTouchingCup);

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioName
{
    namespace MiniGameName
    {
        /// <summary>
        /// Paul PARET
        /// </summary>
        public class GoalManager : TimedBehaviour
        {

            [HideInInspector] public bool asWin = false;

            public override void Start()
            {
                base.Start(); //Do not erase this line!

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!


            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

                if (Tick == 8)
                {
                    if (asWin)
                    {
                        //Manager.Instance.Result(true);
                    }
                    else
                    {
                        //Manager.Instance.Result(false);
                    }
                }

            }


            private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.gameObject.tag == "Player")
                {
                    asWin = true;
                    Debug.Log("You Win");
                }
            }
        }
    }
}
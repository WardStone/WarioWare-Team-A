using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace TrioName
{
    namespace MiniGameName
    {
        public class EnnemiBridge : TimedBehaviour
        {
            [HideInInspector] public bool win = false;
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

            }


            private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.gameObject.tag == "Projectile")
                {
                    win = true;
                    //Manager.Instance.Result(true);
                    Debug.Log("Win");
                }
            }
        }
    }
}
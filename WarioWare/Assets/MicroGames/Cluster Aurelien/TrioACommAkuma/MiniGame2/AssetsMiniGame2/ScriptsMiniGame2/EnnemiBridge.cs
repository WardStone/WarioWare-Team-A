using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace TrioName
{
    namespace MiniGameName
    {
        /// <summary>
        /// Simon PICARDAT
        /// </summary>
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
                if (Tick == 8 && win == false)
                    Manager.Instance.Result(false);
            }


            private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.gameObject.tag == "Projectile")
                {
                    win = true;
                    Manager.Instance.Result(true);
                    other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    Debug.Log("Win" + Tick);
                }
            }
        }
    }
}
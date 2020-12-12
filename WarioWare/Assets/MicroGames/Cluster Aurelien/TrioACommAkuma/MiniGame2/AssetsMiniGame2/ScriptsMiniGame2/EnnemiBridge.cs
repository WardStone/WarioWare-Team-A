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
            public GameObject victoriousPirate;
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
                    GameObject pirateInstance = Instantiate(victoriousPirate, other.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                    //pirateInstance.gameObject.GetComponent<Animator>().speed = pirateInstance.gameObject.GetComponent<Animator>().speed * ((bpm / 60) / 1.5f);
                    Destroy(other.gameObject);
                    Debug.Log("Win" + Tick);
                }
            }
        }
    }
}
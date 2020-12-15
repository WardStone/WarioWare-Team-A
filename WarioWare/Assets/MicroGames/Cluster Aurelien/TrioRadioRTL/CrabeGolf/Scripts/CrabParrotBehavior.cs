using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace RadioRTL
{
    /// <summary>
    /// Théo Valet
    /// </summary>

    namespace CrabGolf
    {


        public class CrabParrotBehavior : TimedBehaviour
        {

            private Vector3 target;
            public float speed;
            private Vector3 position;
            public bool isShot;
            bool isFlying;

            public override void Start()
            {
                base.Start();

                target = new Vector3(8, -3, 0);
                position = gameObject.transform.position;
            }

            void Update()
            {
                float step = (speed * Time.deltaTime / 2 )* bpm;
                transform.position = Vector3.MoveTowards(transform.position, target, step);

                if (gameObject.transform.position == target)
                {
                    Destroy(gameObject);
                }

                if (isShot)
                {
                    CrabSpawner.cs.lose = true;
                    if (!isFlying)
                    {
                        target = new Vector3(Random.Range(-8f, 8f), 3f, 0f);
                        isFlying = true;
                    }

                    speed = 0.5f;
                }
            }
        }
    }
}
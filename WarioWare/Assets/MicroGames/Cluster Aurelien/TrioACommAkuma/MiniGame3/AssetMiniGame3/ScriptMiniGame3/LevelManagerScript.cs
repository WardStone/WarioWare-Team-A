using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACommeAkuma
{
    namespace SaveThePirate
    {
        /// <summary>
        /// PARET Paul
        /// </summary>
        public class LevelManagerScript : TimedBehaviour
        {
            [Header("Levels")]
            public GameObject level1Prefab;
            public GameObject level2Prefab;
            public GameObject level3Prefab;

            [Header("Difficulty")]
            [Range(1, 3)] public int difficulty;


            public override void Start()
            {
                base.Start(); //Do not erase this line!

                if (difficulty == 1)
                {
                    Instantiate(level1Prefab, transform);
                }
                else if (difficulty == 2)
                {
                    Instantiate(level2Prefab, transform);
                }
                else
                {
                    Instantiate(level3Prefab, transform);
                }

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
        }
    }
}
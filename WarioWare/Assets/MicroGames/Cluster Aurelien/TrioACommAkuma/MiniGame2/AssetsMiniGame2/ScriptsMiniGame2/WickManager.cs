using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioName
{
    namespace MiniGameName
    {
        public class WickManager : TimedBehaviour
        {
            public List<GameObject> wickTick;
            public int tickCount;
            public int tickMax;

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
                if (tickCount == tickMax)
                {
                    gameObject.SetActive(false);
                }

                if (tickCount < tickMax)
                {

                    wickTick[tickCount].SetActive(false);
                    tickCount++;
                    wickTick[tickCount].transform.GetChild(0).gameObject.SetActive(true);
                }
                
            }
        }
    }
}
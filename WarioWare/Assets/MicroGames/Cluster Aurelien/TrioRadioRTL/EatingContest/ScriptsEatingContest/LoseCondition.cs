using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace TrioRadioRTL
{
    namespace EatingContest
    {
        public class LoseCondition : TimedBehaviour
        {
            bool win;
            public PlayerController player;
            public override void Start()
            {
                base.Start(); //Do not erase this line!
                win = player.win;
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
                    if (win)
                    {
                        Manager.Instance.Result(true);
                    }
                    else
                    {
                        Manager.Instance.Result(false);
                    }
                    
                }
            }
        }
    }
}
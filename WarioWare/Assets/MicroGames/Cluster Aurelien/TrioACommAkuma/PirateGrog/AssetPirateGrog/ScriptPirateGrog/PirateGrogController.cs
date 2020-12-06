using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Testing;

namespace TrioName
{
    namespace MiniGameName
    {
        /// <summary>
        /// Bastien PRIGENT
        /// </summary>
        public class PirateGrogController : TimedBehaviour
        {
            [Header ("Grog Var")]
            [SerializeField]
            private Image grog;
            [SerializeField] [Range (0,100)]
            private float grogAmount;
            [SerializeField]
            private float maxGrogAmount;
            [SerializeField]
            private float minGrogAmount;

            [Header ("Speed Var")]
            [SerializeField]
            private int fillSpeed;

            [Header("Tool for Different Cup")]
            [SerializeField]
            private float[] whenToChangeSpeed;
            [SerializeField]
            private int[] changeFillSpeed;


            private float yJoystickRight;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!
            }

            public void Update()
            {
                FillGrog();
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                Win();
            }

            void FillGrog()
            {
                yJoystickRight = Input.GetAxisRaw("Right_Joystick_Y");

                if (yJoystickRight > 0)
                {
                    grogAmount += Time.fixedDeltaTime * fillSpeed * yJoystickRight;
                }

                if (grogAmount > maxGrogAmount)
                {
                    grogAmount = maxGrogAmount;
                }

                grog.fillAmount = grogAmount / maxGrogAmount;


                  for(int i = 0; i < whenToChangeSpeed.Length; i++)                 // Tool that permit easy changing cup shape
                  {
                      if(grogAmount >= whenToChangeSpeed[i])
                      {
                          fillSpeed = changeFillSpeed[i];
                      }
                  }
            }
            
            void Win()
            {
                if (Tick == 8)
                {
                    Debug.Log(Tick);
                    if (grogAmount >= minGrogAmount && grogAmount <= maxGrogAmount)
                    {
                        Debug.Log("win");
                    }
                    else Debug.Log("Lose");

                }
            }
        }
    }
}
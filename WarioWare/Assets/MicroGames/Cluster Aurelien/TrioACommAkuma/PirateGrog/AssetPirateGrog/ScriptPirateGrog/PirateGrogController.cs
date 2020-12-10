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
            private float overFillAmount;
            [SerializeField]
            private float maxGrogAmount;
            [SerializeField]
            private float minGrogAmount;
            private bool overFill = false;

            [Header ("Speed Var")]
            [SerializeField]
            private int fillSpeed;
            [SerializeField]
            private bool canFill = true;

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
                FillGrog();
            }

            public void Update()
            {
                //FillGrog();
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                WinLose();
            }

            void FillGrog()
            {
                yJoystickRight = Input.GetAxisRaw("Right_Joystick_Y");

                if (yJoystickRight > 0 && canFill == true) 
                {
                    grogAmount += Time.fixedDeltaTime * fillSpeed * yJoystickRight;         //Controler
                }

                if (grogAmount > overFillAmount)
                {
                    overFill = true;
                    canFill = false;
                }

                grog.fillAmount = grogAmount / overFillAmount;


                  for(int i = 0; i < whenToChangeSpeed.Length; i++)                 // Tool that permit easy changing cup shape
                  {
                      if(grogAmount >= whenToChangeSpeed[i])
                      {
                          fillSpeed = changeFillSpeed[i];
                      }
                  }
            }
            
            void WinLose()
            {
                if (overFill == true)
                {
                    Manager.Instance.Result(false);
                    Debug.Log("Lose");
                }

                if (Tick == 8)
                {
                    canFill = false;
                    Debug.Log(Tick);
                    if (grogAmount >= minGrogAmount && grogAmount <= maxGrogAmount)     //Make the player win or lose at Tick 8
                    {
                        Manager.Instance.Result(true);
                        Debug.Log("Win");
                    }
                    else
                    {
                        Manager.Instance.Result(false);
                        Debug.Log("Lose");
                    }
                }
            }
        }
    }
}
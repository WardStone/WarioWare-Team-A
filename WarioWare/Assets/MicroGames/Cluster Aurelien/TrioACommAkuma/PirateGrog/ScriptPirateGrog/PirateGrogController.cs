using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            private int fillSpeed;
            private float maxGrogAmount = 100;


            private float yJoystickRight;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!
                yJoystickRight = -Input.GetAxis("Right_Joystick_Y");
                if (yJoystickRight < 0)
                {
                    grogAmount += Time.fixedDeltaTime* fillSpeed*yJoystickRight;
                }

                if (grogAmount > maxGrogAmount)
                {
                    grogAmount = maxGrogAmount;
                }

                grog.fillAmount = grogAmount / maxGrogAmount;
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragons_Peperes
{
    namespace ChasseAuTresor
    {
        /// <summary>
        /// Noé Blanc
        /// </summary>

        public class PlayerController : MonoBehaviour
        {

            private bool canMove;

            public float distance;

            public int inputNumber;

            // Start is called before the first frame update
            void Start()
            {
                canMove = true;

                distance = 1.0f;

                inputNumber = 0;
            }

            private void FixedUpdate()
            {
                if (Mathf.Abs(Input.GetAxisRaw("Left_Joystick_X")) <= 0.2 && Mathf.Abs(Input.GetAxisRaw("Left_Joystick_Y")) <= 0.2)
                {
                    canMove = true;
                }

                if (canMove == true)
                {
                    if (Mathf.Abs(Input.GetAxisRaw("Left_Joystick_X")) >= 0.95f)
                    {
                        transform.position += new Vector3(Input.GetAxisRaw("Left_Joystick_X") * distance, 0, 0);
                        inputNumber = inputNumber + 1;
                        canMove = false;
                    }
                    if (Mathf.Abs(Input.GetAxisRaw("Left_Joystick_Y")) >= 0.95f)
                    {
                        transform.position += new Vector3(0, Input.GetAxisRaw("Left_Joystick_Y") * distance, 0);
                        inputNumber = inputNumber + 1;
                        canMove = false;
                    }
                }
            }
        }
    }
}

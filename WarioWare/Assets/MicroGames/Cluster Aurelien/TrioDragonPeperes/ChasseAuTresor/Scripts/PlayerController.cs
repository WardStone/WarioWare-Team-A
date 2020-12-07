using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragons_Peperes
{
    namespace ChasseAuTresor
    {
        public class PlayerController : MonoBehaviour
        {

            private bool canMove;

            public float distance;

            // Start is called before the first frame update
            void Start()
            {
                canMove = true;

                distance = 1.0f;
            }

            private void FixedUpdate()
            {
                if (Mathf.Abs(Input.GetAxisRaw("Left_Joystick_X")) <= 0.2 && Mathf.Abs(Input.GetAxisRaw("Left_Joystick_Y")) <= 0.2)
                {
                    canMove = true;
                }

                if (canMove == true)
                {
                    if (Mathf.Abs(Input.GetAxisRaw("Left_Joystick_X")) == 1.0f)
                    {
                        transform.position += new Vector3(Input.GetAxisRaw("Left_Joystick_X") * distance, 0, 0);
                        canMove = false;
                    }
                    if (Mathf.Abs(Input.GetAxisRaw("Left_Joystick_Y")) == 1.0f)
                    {
                        transform.position += new Vector3(0, -Input.GetAxisRaw("Left_Joystick_Y") * distance, 0);
                        canMove = false;
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragons_Peperes
{
    namespace CestNotreTresor
    {
        /// <summary>
        /// Mael Ricou
        /// </summary>

        public class PlayerController : MonoBehaviour
        {

            [SerializeField] float speed = 10f;
            private float moveInput;

            [SerializeField]bool canMove;

            Rigidbody2D rb;

            private void Start()
            {
                rb = GetComponent<Rigidbody2D>();
            }

            private void Update()
            {
                //Debug.Log(Input.GetAxis("Left_Joystick_X"));

                if(Mathf.Abs(moveInput) < 0.05 && Mathf.Abs(moveInput) > -0.05)
                {
                    Debug.Log("You can't move mothafacka");
                    speed = 0f;
                }
                else
                {
                    speed = 10f;
                    Debug.Log("puto va la tens de mexer");
                }
            }

            private void FixedUpdate()
            {
                MovePlayer();
            }

            private void MovePlayer()
            {
                moveInput = Input.GetAxisRaw("Left_Joystick_X");
                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            }

        }
    }
}

   

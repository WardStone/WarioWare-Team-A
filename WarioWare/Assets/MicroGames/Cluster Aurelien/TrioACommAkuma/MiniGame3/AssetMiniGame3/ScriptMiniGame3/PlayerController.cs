using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioName
{
    namespace MiniGameName
    {

        /// <summary>
        /// Paul PARET
        /// </summary>
        public class PlayerController : TimedBehaviour
        {
            [Header("Player Movement")]
            public float playerTorqueScale;
            [Range(0f, 10f)] public float playerDragSlow;
            [Range(0f, 10f)] public float playerDragQuick;

            [Header("TickEvent")]
            public float impulseScale;

            [Header("Debug")]
            public float playerTorque;

            private float rBumperHold = 0f;
            private float lBumperHold = 0f;
            private Rigidbody2D playerRb;

            [Header("GameObject References")]
            public GameObject goalManagerGO;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                
                playerRb = GetComponent<Rigidbody2D>();
                playerTorque = 0f;

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                
            }

            private void Update()
            {

                if (Tick < 8 && !goalManagerGO.GetComponent<GoalManager>().asWin)
                {
                    GetInput();
                }

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if (Tick < 8 && !goalManagerGO.GetComponent<GoalManager>().asWin)
                {
                    ApplyImpule();
                }
            }


            private void GetInput()
            {
                rBumperHold = Input.GetAxis("Right_Trigger");

                lBumperHold = Input.GetAxis("Left_Trigger");

                DirManager();
                SpeedManager();
                ApplyTorque();
            }

            private void DirManager()
            {
                if (lBumperHold > 0 && rBumperHold <= 0)
                    playerTorque = -1f * lBumperHold;

                else if (lBumperHold <= 0 && rBumperHold > 0)
                    playerTorque = 1f * rBumperHold;

                else if ((lBumperHold > 0 && rBumperHold > 0) || (lBumperHold <= 0 && rBumperHold <= 0))
                    playerTorque = 0f * lBumperHold * rBumperHold;
            }

            /// <summary>
            /// Set the boat drag to increase and decrease the speed
            /// </summary>
            private void SpeedManager()
            {
                if (lBumperHold > 0 && rBumperHold > 0)
                    playerRb.drag = playerDragQuick;
                else
                    playerRb.drag = playerDragSlow;
            }

            private void ApplyTorque()
            {
                playerRb.AddTorque(playerTorque * playerTorqueScale, ForceMode2D.Force);
            }

            /// <summary>
            /// Give the player an impulse forward (USE IN TIMED UPDATE)
            /// </summary>
            private void ApplyImpule()
            {
                playerRb.AddForce(transform.TransformDirection(Vector2.right) * impulseScale, ForceMode2D.Impulse);
            }
        }
    }
}
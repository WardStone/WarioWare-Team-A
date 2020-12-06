using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACommeAkuma
{
    namespace SaveThePirate
    {

        /// <summary>
        /// Paul PARET
        /// </summary>
        public class PlayerController : TimedBehaviour
        {
            [Header("Player Movement")]
            public float playerTorqueScale;
            [HideInInspector] [Range(0f, 10f)] public float playerDragSlow;
            [HideInInspector] [Range(0f, 10f)] public float playerDragQuick;
            

            [Header("TickEvent")]
            public float impulseScale;
            public float decreaseForceScale;

            [Header("Debug")]
            [SerializeField] private float playerTorque;
            [SerializeField] public bool asWin;

            [Header("GameObject References")]
            public GameObject goalManagerGO;

            private float rBumperHold = 0f;
            private float lBumperHold = 0f;
            private Rigidbody2D playerRb;
            private float decreaseForce;
            private bool canApplyForce;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                
                playerRb = GetComponent<Rigidbody2D>();
                playerTorque = 0f;
                asWin = false;

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                
            }

            private void Update()
            {
                if (Tick <= 8 && Tick > 1 && !asWin)
                {
                    GetInput();
                }

                if (canApplyForce)
                {
                    ApplyForce();
                }

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if (Tick <= 8 && Tick > 1 && !asWin)
                {
                    //ApplyImpule();
                    canApplyForce = true;
                    decreaseForce = 1f;
                }

                else if (Tick > 8)
                {
                    if (asWin)
                    {
                        Debug.Log("You won");
                        //Manager.Instance.Result(true)
                    }
                    else
                    {
                        Debug.Log("You lost");
                        //Manager.Instance.Result(false)
                    }
                }
            }


            private void GetInput()
            {
                rBumperHold = Input.GetAxis("Right_Trigger");

                lBumperHold = Input.GetAxis("Left_Trigger");

                DirManager();
                //SpeedManager();
                ApplyTorque();
            }

            private void DirManager()
            {
                if (lBumperHold > 0 && rBumperHold <= 0)
                    playerTorque = -1f * lBumperHold;

                else if (lBumperHold <= 0 && rBumperHold > 0)
                    playerTorque = 1f * rBumperHold;

                else if ((lBumperHold > 0 && rBumperHold > 0) || (lBumperHold <= 0 && rBumperHold <= 0))
                    playerTorque = 0f;
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

            private void ApplyForce()
            {
                playerRb.AddForce(transform.TransformDirection(Vector2.right) * decreaseForce * impulseScale, ForceMode2D.Force);

                decreaseForce -= decreaseForceScale * Time.deltaTime;

                if (decreaseForce <= 0f)
                {
                    decreaseForce = 0f;
                    canApplyForce = false;
                }
            }

            private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.gameObject.tag == "Finish" && !asWin)
                {
                    asWin = true;
                    playerRb.velocity = Vector2.zero;
                }
            }
        }
    }
}
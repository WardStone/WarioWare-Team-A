using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

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
            public float rotationSpeed;
            
            [Header("TickEvent")]
            public float boostStrengh;
            public float velocityLossSpeed;

            [Header("Debug")]
            [SerializeField] private float rotationDir;
            [SerializeField] public bool asWin;

            [Header("GameObject References")]
            public GameObject exploVfx;
            public GameObject goalGO;


            private float rBumperHold = 0f;
            private float lBumperHold = 0f;
            private Rigidbody2D playerRb;
            private float velocityLoss;
            private bool canApplyForce;
            private GameObject motorGO;
            private GameObject vfxAnchor;
            

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                
                playerRb = GetComponent<Rigidbody2D>();
                rotationDir = 0f;
                asWin = false;
                motorGO = transform.GetChild(1).gameObject;
                vfxAnchor = motorGO.transform.GetChild(0).gameObject;

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                if (Tick <= 8 && !asWin)
                {
                    GetInput();
                    RotateMotor();

                    if (Tick > 1 && canApplyForce)
                    {
                        ApplyForce();
                    }
                }
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if (Tick <= 8 && Tick > 1 && !asWin)
                {
                    ActivateExplo();
                    canApplyForce = true;
                    velocityLoss = 1f;
                }

                else if (Tick > 8)
                {
                    if (asWin)
                    {
                        Debug.Log("You won");
                        Manager.Instance.Result(true);
                    }
                    else
                    {
                        Debug.Log("You lost");
                        Manager.Instance.Result(false);
                    }
                }
            }


            private void GetInput()
            {
                rBumperHold = Input.GetAxis("Right_Trigger");

                lBumperHold = Input.GetAxis("Left_Trigger");

                DirManager();
                ApplyTorque();
            }

            private void DirManager()
            {
                if (lBumperHold > 0 && rBumperHold <= 0)
                    rotationDir = -1f * lBumperHold;

                else if (lBumperHold <= 0 && rBumperHold > 0)
                    rotationDir = 1f * rBumperHold;

                else if ((lBumperHold > 0 && rBumperHold > 0) || (lBumperHold <= 0 && rBumperHold <= 0))
                    rotationDir = 0f;
            }

            private void ApplyTorque()
            {
                playerRb.AddTorque((rotationDir * rotationSpeed), ForceMode2D.Force);
            }

            private void ApplyForce()
            {
                playerRb.AddForce(transform.TransformDirection(Vector2.right) * boostStrengh * velocityLoss , ForceMode2D.Force);

                if (velocityLoss > 0f)
                    velocityLoss -= velocityLossSpeed * Time.deltaTime;

                else
                    canApplyForce = false;
            }

            private void RotateMotor()
            {
                if (lBumperHold > 0 && rBumperHold <= 0)
                    motorGO.transform.localEulerAngles = new Vector3(0f, 0f, 25f * lBumperHold);

                else if (lBumperHold <= 0 && rBumperHold > 0)
                    motorGO.transform.localEulerAngles = new Vector3(0f, 0f, -25f * rBumperHold);

                else if ((lBumperHold > 0 && rBumperHold > 0) || (lBumperHold <= 0 && rBumperHold <= 0))
                    motorGO.transform.localEulerAngles = Vector3.zero;
            }

            private void ActivateExplo()
            {
                Instantiate(exploVfx, vfxAnchor.transform.position, Quaternion.identity, vfxAnchor.transform);
            }


            private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.gameObject.tag == "Finish" && !asWin)
                {
                    asWin = true;

                    goalGO.transform.GetChild(0).GetComponent<Animator>().SetBool("AsWin", true);

                    playerRb.velocity = Vector2.zero;
                }
            }
        }
    }
}
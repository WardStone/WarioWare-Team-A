﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TrioName
{
    namespace MiniGameName
    {
        /// <summary>
        /// Simon PICARDAT
        /// </summary>
        public class PlayerController : MonoBehaviour
        {
            public Rigidbody2D anchorRb;
            public float playerForce;
            public float cannonMass;
            /*public HingeJoint2D cannnonHinge;
            public bool canLift;*/

            private void Start()
            {
                anchorRb.gravityScale = cannonMass;
            }
            void Update()
            {
                if (Input.GetButtonDown("A_Button") /*&& canLift*/)
                {
                    /*canLift = false;
                    StartCoroutine(cooldownCannon());
                    cannnonHinge.useMotor = true;*/
                    anchorRb.velocity = Vector2.up * playerForce;
                    //anchorRb.AddForce(Vector2.up * playerForce*50);
                    Debug.Log("up");
                    Debug.Log(anchorRb.velocity);
                }
            }
            /*
                IEnumerator cooldownCannon()
                {
                    yield return new WaitForSeconds(0.2f);
                    cannnonHinge.useMotor = false;
                    canLift = true;
                }*/
        }
    }
}

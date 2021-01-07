using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACommeAkuma
{
    namespace PirateGrog
    {
        /// <summary>
        /// PARET Paul
        /// </summary>
        public class LiquidTrailBehavior : MonoBehaviour
        {
            private LineRenderer liquidRenderer;

            public Transform startPoint;
            public Transform endPoint;

            public float dropSpeed;

            private void Awake()
            {
                liquidRenderer = this.GetComponent<LineRenderer>();
            }

            private void Update()
            {
                liquidRenderer.SetPosition(0, startPoint.position);
                liquidRenderer.SetPosition(1, endPoint.position);

                GetInput();

                if (startPoint.GetComponent<LiquidCollisionDetection>().asCollided)
                {
                    CollisionEvent();
                }
            }

            private void GetInput()
            {
                bool spaceIsPressed = Input.GetKeyDown(KeyCode.Space);
                bool spaceIsReleased = Input.GetKeyUp(KeyCode.Space);

                if (spaceIsPressed)
                    StartDrop();

                if (spaceIsReleased)
                    EndDrop();

            }

            private void StartDrop()
            {
                startPoint.position = Vector2.zero;
                endPoint.position = Vector2.zero;

                endPoint.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                startPoint.GetComponent<Rigidbody2D>().gravityScale = 0f;
                endPoint.GetComponent<Rigidbody2D>().gravityScale = dropSpeed;
            }

            private void EndDrop()
            {
                startPoint.GetComponent<BoxCollider2D>().isTrigger = false;
                startPoint.GetComponent<Rigidbody2D>().gravityScale = dropSpeed;
            }

            private void CollisionEvent()
            {
                startPoint.GetComponent<BoxCollider2D>().isTrigger = true;

                startPoint.GetComponent<Rigidbody2D>().gravityScale = 0f;
                endPoint.GetComponent<Rigidbody2D>().gravityScale = 0f;

                startPoint.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                endPoint.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                startPoint.position = Vector2.zero;
                endPoint.position = Vector2.zero;

                startPoint.GetComponent<LiquidCollisionDetection>().asCollided = false;
            }
        }
    }
}


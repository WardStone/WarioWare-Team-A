using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioName
{
    namespace MiniGameName
    {
        public class CannonControler : TimedBehaviour
        {

            public GameObject anchorActuel;

            [HideInInspector]public Vector2 initialVelocity;


            public float cannonForce;
            public float projectileGravity;
            public GameObject pirateProject;


            [HideInInspector] public bool isLaunched;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!
                initialVelocity = anchorActuel.transform.position - gameObject.transform.position;

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if(Tick == 8)
                {
                    if (isLaunched == false)
                    {
                        LaunchPirate();
                        isLaunched = true;
                    }
                }
            }
            public void LaunchPirate()
            {
               GameObject bulletInstance = Instantiate(pirateProject, anchorActuel.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                Rigidbody2D rbPirate;
                rbPirate = bulletInstance.GetComponent<Rigidbody2D>();
                rbPirate.gravityScale = projectileGravity;
                rbPirate.velocity = initialVelocity.normalized*cannonForce;
            }
        }
    }
}
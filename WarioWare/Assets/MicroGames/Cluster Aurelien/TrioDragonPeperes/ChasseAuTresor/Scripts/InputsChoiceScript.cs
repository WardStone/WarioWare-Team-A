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

        public class InputsChoiceScript : TimedBehaviour
        {
            
            private int possibilityNumber;

            private Vector3[] easyInputLocationList = { new Vector3(-3.7f, 0, 0), new Vector3(0, 0, 0), new Vector3(3.7f, 0, 0) };

            public GameObject upArrow;
            public GameObject downArrow;
            public GameObject leftArrow;
            public GameObject rightArrow;

            public float duration;

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                duration = 2f;

                for (int i = 0; i < 3; i++)
                {
                    possibilityNumber = Random.Range(1, 5);

                    switch(possibilityNumber)
                    {
                        case 1:
                            if(i == 0)
                            {
                                GameObject input1 = Instantiate(upArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input1, duration);
                            }
                            if (i == 1)
                            {
                                GameObject input2 = Instantiate(upArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input2, duration);
                            }
                            if (i == 2)
                            {
                                GameObject input3 = Instantiate(upArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input3, duration);
                            }                            
                            break;
                        case 2:
                            if (i == 0)
                            {
                                GameObject input1 = Instantiate(downArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input1, duration);
                            }
                            if (i == 1)
                            {
                                GameObject input2 = Instantiate(downArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input2, duration);
                            }
                            if (i == 2)
                            {
                                GameObject input3 = Instantiate(downArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input3, duration);
                            }
                            break;
                        case 3:
                            if (i == 0)
                            {
                                GameObject input1 = Instantiate(leftArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input1, duration);
                            }
                            if (i == 1)
                            {
                                GameObject input2 = Instantiate(leftArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input2, duration);
                            }
                            if (i == 2)
                            {
                                GameObject input3 = Instantiate(leftArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input3, duration);
                            }
                            break;
                        case 4:
                            if (i == 0)
                            {
                                GameObject input1 = Instantiate(rightArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input1, duration);
                            }
                            if (i == 1)
                            {
                                GameObject input2 = Instantiate(rightArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input2, duration);
                            }
                            if (i == 2)
                            {
                                GameObject input3 = Instantiate(rightArrow, easyInputLocationList[i], Quaternion.identity);
                                Destroy(input3, duration);
                            }
                            break;
                    }
                }
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!



            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }
            
        }
    }
}
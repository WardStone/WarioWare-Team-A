using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace Dragons_Peperes
{
    namespace ChasseAuTresor
    {
        /// <summary>
        /// Noé Blanc
        /// </summary>

        public class WinOrLooseScript : TimedBehaviour
        {
            public GameObject player;

            private bool hasWon;

            private int inputNumber;

            private int inputNumberToWin;

            public override void Start()
            {
                base.Start(); //Do not erase this line!

                hasWon = false;

                

                if(currentDifficulty == Difficulty.EASY)
                {
                    inputNumberToWin = 3;
                }
                if (currentDifficulty == Difficulty.MEDIUM)
                {
                    inputNumberToWin = 4;
                }
                if (currentDifficulty == Difficulty.HARD)
                {
                    inputNumberToWin = 5;
                }
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

                inputNumber = player.GetComponent<PlayerController>().inputNumber;

                if (transform.position == player.transform.position && inputNumber >= inputNumberToWin)
                {
                    Debug.Log("Gagné !");
                    hasWon = true;
                    Manager.Instance.Result(true);
                }
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                if(Tick == 8 && hasWon == false)
                {
                    Debug.Log("Perdu !");
                    Manager.Instance.Result(false);
                }
            }
        }
    }
}
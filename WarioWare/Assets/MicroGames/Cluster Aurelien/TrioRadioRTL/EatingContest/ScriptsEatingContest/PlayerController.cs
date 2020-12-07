using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

/// <summary>
/// DEUTSCHMANN Lucas
/// </summary>

namespace TrioRadioRTL
{
    namespace EatingContest
    {
        public class PlayerController : MonoBehaviour
        {

            [Header ("Parameters")]
            public int chomp; //the number of chomps the player has currently had
            public int numberOfChomps; //the number of chomps required to finish a plate
            public int numberOfPlates; //the number of plates the player need to eat to finish the mini game
            int numberOfRottenPlates; //the number of rotten plates the player will need to avoid

            public bool rottenPlate = false; //the state of the current plate
            [Header("Difficulty")]
            public int rottenPlatesEasy;
            public int rottenPlatesMedium;
            public int rottenPlatesHard;
            public int numberOfPlatesEasy;
            public int numberOfPlatesMedium;
            public int numberOfPlatesHard;

            // Start is called before the first frame update
            void Start()
            {
                if (Manager.Instance.currentDifficulty == Manager.Difficulty.EASY)
                {
                    numberOfPlates = numberOfPlatesEasy;
                    numberOfRottenPlates = rottenPlatesEasy;
                }
                else if (Manager.Instance.currentDifficulty == Manager.Difficulty.MEDIUM)
                {
                    numberOfPlates = numberOfPlatesMedium;
                    numberOfRottenPlates = rottenPlatesMedium;
                }
                else if (Manager.Instance.currentDifficulty == Manager.Difficulty.HARD)
                {
                    numberOfPlates = numberOfPlatesHard;
                    numberOfRottenPlates = rottenPlatesHard;
                }
            }

            // Update is called once per frame
            void Update()
            {
                if (!rottenPlate) //plate isn't rotten
                {
                    if (/*Input.GetButtonDown("A_Button")*/Input.GetKeyDown("e"))
                    {
                        chomp += 1;
                    }

                    if (chomp == numberOfChomps && numberOfPlates != 0) //if the player eats everything in the plate
                    {
                        chomp = 0;
                        numberOfPlates -= 1;
                        NextPlate(); //Changing Plates
                    }
                    if (Input.GetKeyDown("a"))
                    {
                        chomp = 0;
                        NextPlate();
                    }
                }
                else if (rottenPlate)//plate is rotten
                { 
                    if (/*Input.GetButtonDown("X_Button")*/Input.GetKeyDown("a"))
                    {

                        NextPlate();
                    }
                    if (/*Input.GetButtonDown("A_Button") */Input.GetKeyDown("e"))
                    {
                        Manager.Instance.Result(false);
                    }
                }

                if (numberOfPlates == 0) //if there are no more plaets the player wins
                {
                    EndMinigame();
                }
            }

            void NextPlate()//changing the plate once its empty
            {
                if (Random.Range(0,numberOfRottenPlates+1) != 0)
                {
                    rottenPlate = true;
                    numberOfRottenPlates -= 1;
                }
                else
                {
                    rottenPlate = false;
                }

            }

            void EndMinigame()//ending the mini game
            {
                Manager.Instance.Result(true);
            }
        }
    }
}

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


            public Transform target;
            Vector3 basePosition;
            Vector3 moveVector;
            [HideInInspector]
            public bool win;
            public float speed;
            bool movePlate = true;
            public GameObject platesManager;
            // Start is called before the first frame update
            void Start()
            {
                basePosition = transform.position;
                platesManager.transform.position = basePosition;
                moveVector = (target.position - transform.position).normalized;
                if (Manager.Instance.currentDifficulty == Difficulty.EASY)
                {
                    numberOfPlates = numberOfPlatesEasy;
                    numberOfRottenPlates = rottenPlatesEasy;
                }
                else if (Manager.Instance.currentDifficulty == Difficulty.MEDIUM)
                {
                    numberOfPlates = numberOfPlatesMedium;
                    numberOfRottenPlates = rottenPlatesMedium;
                }
                else if (Manager.Instance.currentDifficulty == Difficulty.HARD)
                {
                    numberOfPlates = numberOfPlatesHard;
                    numberOfRottenPlates = rottenPlatesHard;
                }
            }

            // Update is called once per frame
            void Update()
            {
                if (movePlate)
                {
                    platesManager.transform.position += Vector3.right * speed * Time.deltaTime;
                    if (platesManager.transform.position.x >=0)
                    {
                        movePlate = false;
                    }
                }
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
                platesManager.transform.position = basePosition;
                movePlate = true;
                if (Random.Range(0,numberOfRottenPlates) != 0)
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
                win = true;
                Manager.Instance.Result(true);
            }
        }
    }
}

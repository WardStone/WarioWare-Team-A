using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragons_Peperes
{
    namespace CestNotreTresor
    {
        /// <summary>
        /// Mael Ricou
        /// </summary>

        public class EnemyController : MonoBehaviour
        {
            public float enemySpeed = 5.5f;
            [SerializeField] float enemyXSpeed = 4;

            public Transform target;


            public float bound_Y;

            private EnemyManager minigameManager;

            private void Start()
            {
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                minigameManager = FindObjectOfType<EnemyManager>();

                if(minigameManager.bpm > 90)
                {
                    enemySpeed = enemySpeed * 1.2f;
                }

                if(minigameManager.bpm >= 140f)
                {
                    enemySpeed = enemySpeed * 1.5f;
                }

                
            }


            private void Update()
            {
                MoveEnemy();
            }

            void MoveEnemy()
            {
                //se dirige vers l'axe X du Joueur
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), enemyXSpeed * Time.deltaTime);

                //se déplace sur l'axe Y en négatif
                Vector2 temp = transform.position;
                temp.y -= enemySpeed * Time.deltaTime;
                transform.position = temp;

                //si l'ennemi dépasse un certain axe, se fait détruire
                if (temp.y < bound_Y)
                    Destroy(gameObject, 1);
            }

            private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.name == "Player")
                {
                    Debug.Log("Game Lost");

                    minigameManager.YouLost();
                }
            }
        }

    }
}

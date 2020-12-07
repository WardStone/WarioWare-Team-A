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
            [SerializeField] float enemySpeed = 6;
            [SerializeField] float enemyXSpeed = 4;

            public Transform target;


            public float bound_Y;


            private void Start()
            {
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
                }
            }
        }

    }
}

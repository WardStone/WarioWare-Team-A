using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadioRTL
{
    /// <summary>
    /// Théo Valet
    /// </summary>

    namespace CrabGolf
    {
        public class PlayerBehavior : MonoBehaviour
        {
            Animator animator;
            public bool strikeUnlock = false;
            public float animFrappe;
            bool isInAnim;
            public bool canShoot = true;
            public bool hit;

            private void Start()
            {
                animator = GetComponent<Animator>();     
            }

            void Update()
            {
                if (canShoot)
                {
                    if (Input.GetButton("A_Button") && !hit)
                    {
                        strikeUnlock = true;
                        animator.SetBool("Prepare", true);
                    }
                    else if (Input.GetButtonUp("A_Button") && strikeUnlock && !hit)
                    {                        
                        animator.SetBool("Shoot", true);
                        strikeUnlock = false;
                        StartCoroutine(ResetHit());
                    }
                    else if (!strikeUnlock)
                    {
                        animator.SetBool("Prepare", false);
                        animator.SetBool("Shoot", false);     
                    }
                }            
            }     
            IEnumerator ResetHit()
            {
                hit = true;

                yield return new WaitForSeconds(animFrappe);
                hit = false;
            }
            
            private void OnTriggerStay2D(Collider2D other)
            {
                if (canShoot)
                {
                        NormalCrabBehaviour ncb = other.GetComponent<NormalCrabBehaviour>();
                        CrabParrotBehavior cpb = other.GetComponent<CrabParrotBehavior>();

                        if (ncb != null)
                        {
                            ncb.isShot = true;
                        }
                        else if (cpb != null)
                        {
                            cpb.isShot = true;
                            canShoot = false;
                            animator.SetBool("Lose", true);
                        }
                    
                }
                
            }
          
        }
    }
  
}

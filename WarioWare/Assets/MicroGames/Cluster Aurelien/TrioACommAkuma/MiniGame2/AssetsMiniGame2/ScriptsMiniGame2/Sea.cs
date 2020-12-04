using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace TrioName
{
    namespace MiniGameName
    {
        public class Sea : MonoBehaviour
        {
            public bool loose;
            private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.gameObject.tag == "Projectile")
                {
                    loose = true;
                    //Manager.Instance.Result(true);
                    Debug.Log("Looser");
                }
            }
        }

    }
}

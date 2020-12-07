using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadioRTL
{
    /// <summary>
    /// Théo Valet
    /// </summary>
}
public class PlayerBehavior : MonoBehaviour
{
    public bool StrikeUnlock = false;
    public GameObject NormalCrab;


    void Start()
    {

        if (Input.GetButtonDown("A_Button"))
        {
            StrikeUnlock = true;
            Frappe();
        }
    }

    void Frappe()
    {
        if (Input.GetButtonUp("A_Button") && StrikeUnlock)
        {
            Destroy(gameObject);
        }
    }

}

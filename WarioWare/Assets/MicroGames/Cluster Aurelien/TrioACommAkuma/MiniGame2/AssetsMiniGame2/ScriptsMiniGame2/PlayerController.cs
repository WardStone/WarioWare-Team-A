using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D anchorRb;
    public float playerForce;
    public float cannonMass;

    private void Start()
    {
        anchorRb.gravityScale = cannonMass;
    }
    void Update()
    {

        if (Input.GetButtonDown("A_Button"))
        {
            anchorRb.velocity = Vector2.up * playerForce;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadioRTL
{
    /// <summary>
    /// Théo Valet
    /// </summary>
}
    public class NormalCrabBehaviour : MonoBehaviour
{
    private Vector3 target;
    public float speed;
    private Vector3 position;

    void Start()
    {
        target = new Vector3(8, -3, 0);
        position = gameObject.transform.position;
        speed = 1.0f;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

    }
}

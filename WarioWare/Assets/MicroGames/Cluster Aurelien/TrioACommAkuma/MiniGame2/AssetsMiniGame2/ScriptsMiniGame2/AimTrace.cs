using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTrace : MonoBehaviour
{
    public Vector2 direction;
    public float force;
    public GameObject PointPrefab;
    public GameObject[] Points;

    public int numberOfPoints;
    void Start()
    {
        Points = new GameObject[numberOfPoints];
        for (int i=0; i < numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 landingPoint =
    }
}

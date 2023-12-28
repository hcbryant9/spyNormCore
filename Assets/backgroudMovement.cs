using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroudMovement : MonoBehaviour
{
    public float speed = 0.2f; // Adjust the speed here

    void Update()
    {
        // Move the object to the right
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}

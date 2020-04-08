using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0, 0, 0.2f);
        if (transform.position.z > 50) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -50);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject instance;

    [SerializeField]
    int instances = 10000;

    void Start()
    {
        for (int i = 0; i < instances; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            Instantiate(instance, pos, Quaternion.identity);
        }
    }
}

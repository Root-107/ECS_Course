using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class SpawnDOTS : MonoBehaviour
{
    //Parallel processing using jobs

    [SerializeField]
    GameObject instance;

    Transform[] items;

    private int count = 20000;

    struct MoveJob : IJobParallelForTransform
    {
        public void Execute(int index, TransformAccess transform)
        {
            transform.position += new Vector3(0, 0, 0.2f);
            if (transform.position.z > 50)
            {
                transform.position = new Vector3(transform.position.x, 0, -50);
            }
        }
    };

    MoveJob moveJob;
    JobHandle moveHandle;
    TransformAccessArray transforms;

    void Start() 
    {
        items = new Transform[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            GameObject item = Instantiate(instance, pos, Quaternion.identity);
            items[i] = item.transform;
        }

        transforms = new TransformAccessArray(items);
    }

    void Update()
    {
        moveJob = new MoveJob { };
        moveHandle = moveJob.Schedule(transforms);
    }

    private void LateUpdate()
    {
        moveHandle.Complete();
    }

    private void OnDestroy()
    {
        transforms.Dispose();
    }
}

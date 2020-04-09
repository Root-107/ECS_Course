using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class DataSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        JobHandle handler = Entities.WithName("DataSystem").ForEach((ref Translation pos) =>
        {
        }).Schedule(inputDeps);
        return handler;
    }
}

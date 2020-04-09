//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Unity.Entities;
//using Unity.Mathematics;
//using Unity.Transforms;
//using Unity.Jobs;

//public class MoveSystem : JobComponentSystem
//{
//    protected override JobHandle OnUpdate(JobHandle inputDeps)
//    {
//        JobHandle jobHandle = Entities.WithName("MoveSystem")
//            .ForEach((ref Translation pos, ref Rotation qua) =>
//            {
//                pos.Value += new float3(0, 0.1f, 0);
//                if (pos.Value.y > 100)
//                {
//                    pos.Value.y = 0;
//                }
//            }).Schedule(inputDeps);

//        return jobHandle;
//    }
//}

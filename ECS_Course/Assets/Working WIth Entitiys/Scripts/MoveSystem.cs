using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Unity.Mathematics;
//using Unity.Transforms;
//using Unity.Entities;
//using Unity.Jobs;

//public class MoveSystem : JobComponentSystem
//{
//    protected override JobHandle OnUpdate(JobHandle inputDeps)
//    {
//        JobHandle jobHandler = Entities.WithName("MoveSystem").ForEach((ref Translation pos, ref Rotation rot) =>
//        {
//            //pos.Value += 0.01f * math.up();
//        }).Schedule(inputDeps);

//        return jobHandler;
//    }
//}

//public class ScaleSystem : JobComponentSystem
//{
//    protected override JobHandle OnUpdate(JobHandle inputDeps)
//    {
//        JobHandle handeler = Entities.WithName("ScaleSystem").ForEach((ref NonUniformScale scale) =>
//        {
//            //if (scale.Value.x != 1)
//            //{
//            //    scale.Value = 2;
//            //}

//        }).Schedule(inputDeps);

//        return handeler;
//    }
//}

//public class SheepSystem : JobComponentSystem
//{
//    protected override JobHandle OnUpdate(JobHandle inputDeps)
//    {
//        JobHandle handle = Entities.WithName("SheepSystem").ForEach((ref SheepData data, ref Translation pos) =>
//        {
//            pos.Value -= 0.01f * math.up();
//        }).Schedule(inputDeps);

//        return handle;
//    }
//}
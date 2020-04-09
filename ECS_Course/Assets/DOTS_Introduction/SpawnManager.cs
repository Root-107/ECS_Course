//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Unity.Entities;
//using Unity.Mathematics;
//using Unity.Transforms;

//public class SpawnManager : MonoBehaviour
//{

//    EntityManager manager;

//    public GameObject itemPrefab;

//    const int count = 15000;

//    void Start()
//    {
//        manager = World.DefaultGameObjectInjectionWorld.EntityManager;
//        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
//        Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(itemPrefab, settings);

//        for (int i = 0; i < count; i++)
//        {
//            Entity instace = manager.Instantiate(prefab);
//            Vector3 position = transform.TransformPoint(new float3(UnityEngine.Random.Range(-50, 50), UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(-50, 50)));
//            manager.SetComponentData(instace, new Translation { Value = position });
//            manager.SetComponentData(instace, new Rotation { Value = new quaternion(0,0,0,0) });
//        }
//    }
//}
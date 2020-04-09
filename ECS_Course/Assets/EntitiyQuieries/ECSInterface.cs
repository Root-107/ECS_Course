using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;

public class ECSInterface : MonoBehaviour
{
    World world;
    EntityManager manager;
    GameObjectConversionSettings settings;

    GameObject selectedItem;

    [SerializeField]
    Dropdown itemType;

    [SerializeField]
    GameObject[] items;

    [SerializeField]
    Button addItem;

    [SerializeField]
    Text text;

    private void Start()
    {
        world = World.DefaultGameObjectInjectionWorld;
        manager = world.GetExistingSystem<DataSystem>().EntityManager;
        settings = GameObjectConversionSettings.FromWorld(world, null);

        List<string> options = new List<string>();
        for (int i = 0; i < items.Length; i++)
        {
            options.Add(items[i].name);
        }

        itemType.AddOptions(options);

        itemType.onValueChanged.AddListener(HandleDropDownChange);
        addItem.onClick.AddListener(HandleAddItem);

        selectedItem = items[0];
    }

    private void HandleAddItem()
    {
        Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(selectedItem, settings);

        Entity instance = manager.Instantiate(prefab);

        manager.SetComponentData(instance, new Translation {
            Value = new Vector3(UnityEngine.Random.Range(-10, 10), 0, UnityEngine.Random.Range(-10, 10))
        });

        HandleDropDownChange(itemType.value);
    }

    private void HandleDropDownChange(int arg0)
    {
        if (items[arg0] != null)
        {
            selectedItem = items[arg0];
        }

        ComponentType type = null;
        EntityQuery query = null;

        switch (arg0) 
        {
            case 0:
                type = ComponentType.ReadOnly<SheepData>();
                break;
            case 1:
                type = ComponentType.ReadOnly<TankData>();
                break;
            default:
                type = null;
                break;
        }

        if (type != null)
        {
            query = manager.CreateEntityQuery(type);

            text.text = query.CalculateEntityCount().ToString();
        }
        else {
            text.text = "No entitys";
        }
    }
}

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
    Dropdown countDropDown;

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

        countDropDown.onValueChanged.AddListener(HandleButtonClick);
        itemType.onValueChanged.AddListener(HandleSelectItem);
        addItem.onClick.AddListener(HandleAddItem);

        selectedItem = items[0];
    }

    private void HandleSelectItem(int arg0)
    {
        if (items[arg0] != null)
        {
            selectedItem = items[arg0];
        }
    }

    private void HandleAddItem()
    {
        Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(selectedItem, settings);

        Entity instance = manager.Instantiate(prefab);

        manager.SetComponentData(instance, new Translation {
            Value = new Vector3(UnityEngine.Random.Range(-10, 10), 0, UnityEngine.Random.Range(-10, 10))
        });
    }

    private void HandleButtonClick(int arg0)
    {

        EntityQuery query = null;
        switch (arg0) 
        {
            case 0:
                query = manager.CreateEntityQuery(ComponentType.ReadOnly<TankData>());
                break;
            case 1:
                query = manager.CreateEntityQuery(ComponentType.ReadOnly<SheepData>());
                break;
        }

        text.text = query.CalculateEntityCount().ToString();
    }
}

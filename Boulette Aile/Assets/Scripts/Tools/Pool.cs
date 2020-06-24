using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pool : MonoBehaviour
{
    public static Pool instance;

    public List<GameObject> objectsToPool;
    public int numberToCreateAtStart;
    public Transform poolParent;

    private Dictionary<GameObject, List<GameObject>> pool = new Dictionary<GameObject, List<GameObject>>();

    private void Awake()
    {
        SetAsSingleton();

        foreach (var item in objectsToPool)
        {
            AddToPool(item);
        }
    }

    private void SetAsSingleton()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void AddToPool(GameObject item)
    {
        pool.Add(item, new List<GameObject>());
        for (int i = 0; i < numberToCreateAtStart; i++)
        {
            GameObject newItem = Instantiate(item);
            newItem.SetActive(false);
            pool[item].Add(newItem);
            newItem.transform.SetParent(poolParent);
        }
    }

    public GameObject GetItemFromPool(GameObject item, Vector3 position, Quaternion rotation)
    {
        if (!pool.ContainsKey(item))
        {
            AddToPool(item);
        }

        GameObject newItem = GetNewItem(pool[item]);

        if (!newItem)
        {
            newItem = Instantiate(item);
            pool[item].Add(newItem);
            newItem.transform.SetParent(poolParent);
        }
        newItem.transform.position = position;
        newItem.transform.rotation = rotation;
        newItem.SetActive(true);

        return newItem;
    }

    private GameObject GetNewItem(List<GameObject> itemList)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (!itemList[i].activeSelf)
            {
                return itemList[i];
            }
        }
        return null;
    }
}

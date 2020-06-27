using LowTeeGames.HelperClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class LootBehaviour<T> : MonoBehaviour where T : Enum
{
    public TextMeshPro nameDisplay;
    public T lootType;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void OnEnable()
    {
        GetNewLoot(); 
    }

    private void Update()
    {
        nameDisplay.transform.LookAt(cam.transform.position);
        nameDisplay.transform.Rotate(Vector3.up, 180);
    }

    protected void GetNewLoot()
    {
        lootType = RandomHelper.GetRandomEnum<T>(typeof(T), 1);
        nameDisplay.text = lootType.ToString();
    }
}

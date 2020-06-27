using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPool : MonoBehaviour
{
    private Dictionary<ArmorName, Armor> armorPool = new Dictionary<ArmorName, Armor>();

    public Dictionary<ArmorName, Armor> Pool { get => armorPool; private set => armorPool = value; }

    private void Awake()
    {
        Armor[] armors = GetComponents<Armor>();

        for (int i = 0; i < armors.Length; i++)
        {
            armorPool.Add(armors[i].armorName, armors[i]);
        }
    }
}

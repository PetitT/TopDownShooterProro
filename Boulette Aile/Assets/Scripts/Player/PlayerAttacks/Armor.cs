using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Armor : MonoBehaviour
{
    public ArmorName armorName;
    public int armorValue;
    public float actionCooldown;

    public abstract IEnumerator ExecuteAction(Action onFinish);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Attack : MonoBehaviour
{
    public int damage;
    public int durabitlity;
    public float cooldown;
    public float speed;
    public Transform attackOrigin;

    public abstract IEnumerator DoAttack(Action onFinish);
}

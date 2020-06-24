using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static event Action<int> onHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (other.GetComponent<ProjectileAllegiance>().allegiance == Allegiance.ennemy)
            {
                int damage = other.GetComponent<DamageDealer>().damage;
                onHit?.Invoke(damage);
                other.gameObject.SetActive(false);
            }
        }
    }
}

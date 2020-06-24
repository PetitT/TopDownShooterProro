using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCollider : MonoBehaviour
{
    public static event Action onWeaponCollided;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            onWeaponCollided?.Invoke();
        }
        if (other.CompareTag("Bullet"))
        {
            if(other.GetComponent<ProjectileAllegiance>().allegiance == Allegiance.ennemy)
            {
                onWeaponCollided?.Invoke();
            }
        }
    }
}

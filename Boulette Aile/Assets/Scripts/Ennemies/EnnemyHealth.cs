using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Allegiance projectileAllegiance = other.GetComponent<ProjectileAllegiance>().allegiance;
            if (projectileAllegiance == Allegiance.allied)
            {
                int damage = other.GetComponent<DamageDealer>().damage;
                TakeDamage(damage);
                other.gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("MeleeWeapon"))
        {
            int damage = other.GetComponent<DamageDealer>().damage;
            TakeDamage(damage);
        }
    }
}

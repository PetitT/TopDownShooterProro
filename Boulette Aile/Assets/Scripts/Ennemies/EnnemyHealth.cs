using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    public EnnemyHealthDisplay display;
    public EnnemyLoot loot;
    public int maxHealth;
    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = maxHealth;
        display.UpdateHealth(currentHealth, maxHealth);
    }
    
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        display.UpdateHealth(currentHealth, maxHealth);
        if(currentHealth <= 0)
        {
            loot.Loot();
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
            Debug.Log("hiku");
            int damage = other.GetComponent<DamageDealer>().damage;
            TakeDamage(damage);
        }
    }
}

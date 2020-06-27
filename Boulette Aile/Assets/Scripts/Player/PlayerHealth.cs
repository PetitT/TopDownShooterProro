using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public PlayerHealthDisplay display;
    public PlayerArmor armor;

    private void Start()
    {
        currentHealth = maxHealth;
        display.DisplayHealth(currentHealth, maxHealth);
        PlayerCollision.onHit += OnHitHandler;
    }

    private void OnHitHandler(int damage)
    {
        int remainingDamage = 0;
        armor.CalculateDamage(damage, out remainingDamage);
        currentHealth -= remainingDamage;
        display.DisplayHealth(currentHealth, maxHealth);
        if(currentHealth <= 0)
        {
            Debug.Log("LOL T MORT");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        PlayerCollision.onHit += OnHitHandler;
    }

    private void OnHitHandler(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Debug.Log("LOL T MORT");
        }
    }
}

using LowTeeGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject projectile;
    public Transform shootPos;
    public int numberOfProjectiles;
    public float shootFrequency;
    public float rotationSpeed;
    private float remainingShootFrequency;
    private Vector3 baseRotation;

    private void Start()
    {
        remainingShootFrequency = shootFrequency;
        baseRotation = gameObject.transform.eulerAngles;
    }

    private void Update()
    {
        ShootCooldown();
        Rotate();
    }

    private void Rotate()
    {
        gameObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void ShootCooldown()
    {
        remainingShootFrequency -= Time.deltaTime;
        if (remainingShootFrequency <= 0)
        {
            Shoot();
            remainingShootFrequency = shootFrequency;
        }
    }

    private void Shoot()
    {
        float currentY = gameObject.transform.eulerAngles.y;
        float radiusDelta = 360 / numberOfProjectiles;
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            Pool.instance.GetItemFromPool(projectile, shootPos.position, Quaternion.Euler(baseRotation.x, baseRotation.y + i * radiusDelta + currentY, baseRotation.z));
        }
    }
}

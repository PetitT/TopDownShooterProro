using LowTeeGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangeAttack
{
    public int ballsPerShoot;
    public Vector2 shootRadius;
    public Vector2 speedRange;

    public override IEnumerator DoAttack(Action onFinish)
    {
        Vector3 currentRotation = attackOrigin.eulerAngles;

        for (int i = 0; i < ballsPerShoot; i++)
        {
            float addedRotation = UnityEngine.Random.Range(shootRadius.x, shootRadius.y);
            Quaternion newRotation = Quaternion.Euler(currentRotation.x, currentRotation.y + addedRotation, currentRotation.z);
            GameObject newProjectile = Pool.instance.GetItemFromPool(projectile, attackOrigin.position, newRotation);
            float speed = UnityEngine.Random.Range(speedRange.x, speedRange.y);

            newProjectile.GetComponent<DamageDealer>().damage = damage;
            newProjectile.GetComponent<ForwardMoving>().speed = speed;
            newProjectile.GetComponent<ProjectileAllegiance>().allegiance = Allegiance.allied;
            newProjectile.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        yield return new WaitForSeconds(cooldown);
        onFinish?.Invoke();
    }
}

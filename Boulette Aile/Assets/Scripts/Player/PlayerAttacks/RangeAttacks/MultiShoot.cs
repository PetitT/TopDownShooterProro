using LowTeeGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShoot : RangeAttack
{
    public int numberOfShoots;
    public List<float> angles;

    public override IEnumerator DoAttack(Action onFinish)
    {
        for (int i = 0; i < numberOfShoots; i++)
        {
            Vector3 shootRotation = attackOrigin.eulerAngles;
            Quaternion newRotation = Quaternion.Euler(shootRotation.x, shootRotation.y + angles[i], shootRotation.z);
            GameObject newProjectile = Pool.instance.GetItemFromPool(projectile, attackOrigin.position, newRotation);

            newProjectile.GetComponent<DamageDealer>().damage = damage;
            newProjectile.GetComponent<ForwardMoving>().speed = speed;
            newProjectile.GetComponent<ProjectileAllegiance>().allegiance = Allegiance.allied;
            newProjectile.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        yield return new WaitForSeconds(cooldown);
        onFinish?.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAttack : MonoBehaviour
{
    public GameObject projectile;
    public int numberOfShoots;
    public List<float> angles;
    public Transform attackOrigin;
    public int damage;
    public float speed;
    public float cooldown;

    public IEnumerator Attack(Action onFinish)
    {
        for (int i = 0; i < numberOfShoots; i++)
        {
            Vector3 shootRotation = attackOrigin.eulerAngles;
            Quaternion newRotation = Quaternion.Euler(shootRotation.x, shootRotation.y + angles[i], shootRotation.z);
            GameObject newProjectile = Pool.instance.GetItemFromPool(projectile, attackOrigin.position, newRotation);

            newProjectile.GetComponent<DamageDealer>().damage = damage;
            newProjectile.GetComponent<ForwardMoving>().speed = speed;
            newProjectile.GetComponent<ProjectileAllegiance>().allegiance = Allegiance.ennemy;
        }

        yield return new WaitForSeconds(cooldown);
        onFinish?.Invoke();
    }
}

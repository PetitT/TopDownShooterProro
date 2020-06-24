using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MeleeAttack
{
    public override IEnumerator DoAttack(Action onFinish)
    {
        weapon.SetActive(true);
        weapon.GetComponent<DamageDealer>().damage = damage;
        attackOrigin.transform.localRotation = Quaternion.identity;
        float remainingCooldown = cooldown;

        while (remainingCooldown > 0)
        {
            attackOrigin.transform.Rotate(Vector3.up, speed * Time.deltaTime);
            remainingCooldown -= Time.deltaTime;
            yield return null;
        }

        weapon.SetActive(false);
        onFinish?.Invoke();
    }
}

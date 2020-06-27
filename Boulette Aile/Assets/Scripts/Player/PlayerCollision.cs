using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static event Action<int> onHit;
    public static event Action<MeleeName> onMeleeLoot;
    public static event Action<RangeName> onRangeLoot;
    public static event Action<ArmorName> onArmorLoot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (other.GetComponent<ProjectileAllegiance>().allegiance == Allegiance.ennemy)
            {
                int damage = other.GetComponent<DamageDealer>().damage;
                onHit?.Invoke(damage);
                other.gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("Loot"))
        {
            if (GameobjectHelper.TryGetComponent(other.gameObject, out LootBehaviour<MeleeName> melee))
            {
                onMeleeLoot?.Invoke(melee.lootType);
            }
            if (GameobjectHelper.TryGetComponent(other.gameObject, out LootBehaviour<RangeName> range))
            {
                onRangeLoot?.Invoke(range.lootType);
            }
            if(GameobjectHelper.TryGetComponent(other.gameObject, out LootBehaviour<ArmorName> armor))
            {
                onArmorLoot?.Invoke(armor.lootType);
            }

            other.gameObject.SetActive(false);
        }
    }
}

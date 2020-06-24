using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AttackPool attackPool;

    private MeleeName startMeleeWeapon = MeleeName.baseMelee;
    private RangeName startRangeWeapon = RangeName.baseRange;

    private bool canAttack = true;

    private MeleeAttack currentMelee;
    private int meleeAmmo;
    private RangeAttack currentRange;
    private int rangeAmmo;

    private void Start()
    {
        ModifyWeapon(startMeleeWeapon);
        ModifyWeapon(startRangeWeapon);

        InputManager.onRangeAttack += RangeAttackHandler;
        InputManager.onMeleeAttack += MeleeAttackHandler;
        PlayerWeaponCollider.onWeaponCollided += WeaponCollideHandler;
    }

    private void OnDestroy()
    {
        InputManager.onRangeAttack -= RangeAttackHandler;
        InputManager.onMeleeAttack -= MeleeAttackHandler;
        PlayerWeaponCollider.onWeaponCollided -= WeaponCollideHandler;
    }

    private void RangeAttackHandler()
    {
        if (canAttack)
        {
            if (meleeAmmo != 0)
            {
                canAttack = false;
                rangeAmmo--;
                StartCoroutine(currentMelee.DoAttack(() => canAttack = true));
            }
            else
            {
                ModifyWeapon(MeleeName.baseMelee);
            }
        }
    }

    private void MeleeAttackHandler()
    {
        if (canAttack)
        {
            if (meleeAmmo != 0)
            {
                canAttack = false;
                StartCoroutine(currentRange.DoAttack(() => canAttack = true));
            }
            else
            {
                ModifyWeapon(RangeName.baseRange);
            }
        }
    }

    private void WeaponCollideHandler()
    {
        meleeAmmo--;
    }

    private void ModifyWeapon(MeleeName attackName)
    {
        MeleeAttack melee = attackPool.GetAttack(attackName);
        currentMelee = melee;
        meleeAmmo = melee.durabitlity;
    }

    private void ModifyWeapon(RangeName attackName)
    {
        RangeAttack range = attackPool.GetAttack(attackName);
        currentRange = range;
        rangeAmmo = range.durabitlity;
    }

    
}

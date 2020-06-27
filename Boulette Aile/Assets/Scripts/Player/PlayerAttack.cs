using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AttackPool attackPool;

    public MeleeName startMeleeWeapon;
    public RangeName startRangeWeapon;

    private bool canAttack = true;

    public MeleeAttack currentMelee { get; private set; }
    public int meleeAmmo { get; private set; }
    public RangeAttack currentRange { get; private set; }
    public int rangeAmmo { get; private set; }

    private void Start()
    {
        ModifyWeapon(startMeleeWeapon);
        ModifyWeapon(startRangeWeapon);

        InputManager.onRangeAttack += RangeAttackHandler;
        InputManager.onMeleeAttack += MeleeAttackHandler;
        PlayerWeaponCollider.onWeaponCollided += WeaponCollideHandler;
        PlayerCollision.onMeleeLoot += MeleeLootHandler;
        PlayerCollision.onRangeLoot += RangeLootHandler;
    }

    private void OnDestroy()
    {
        InputManager.onRangeAttack -= RangeAttackHandler;
        InputManager.onMeleeAttack -= MeleeAttackHandler;
        PlayerWeaponCollider.onWeaponCollided -= WeaponCollideHandler;
        PlayerCollision.onMeleeLoot -= MeleeLootHandler;
        PlayerCollision.onRangeLoot -= RangeLootHandler;
    }


    private void RangeLootHandler(RangeName obj)
    {
        ModifyWeapon(obj);
    }

    private void MeleeLootHandler(MeleeName obj)
    {
        ModifyWeapon(obj);
    }

    private void RangeAttackHandler()
    {
        if (canAttack)
        {
            if (rangeAmmo != 0)
            {
                canAttack = false;
                rangeAmmo--;
                StartCoroutine(currentRange.DoAttack(() => canAttack = true));
                if(rangeAmmo <= 0)
                {
                    ModifyWeapon(RangeName.baseRange);
                }
            }
            else
            {
                ModifyWeapon(RangeName.baseRange);
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
                StartCoroutine(currentMelee.DoAttack(() => canAttack = true));
            }
            else
            {
                ModifyWeapon(MeleeName.baseMelee);
            }
        }
    }

    private void WeaponCollideHandler()
    {
        meleeAmmo--;
        if(meleeAmmo <= 0)
        {
            ModifyWeapon(MeleeName.baseMelee);
        }
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

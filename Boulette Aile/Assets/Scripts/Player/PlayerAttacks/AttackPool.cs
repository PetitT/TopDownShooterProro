using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPool : MonoBehaviour
{
    private Dictionary<MeleeName, MeleeAttack> meleeAttacks = new Dictionary<MeleeName, MeleeAttack>();
    private Dictionary<RangeName, RangeAttack> rangeAttacks = new Dictionary<RangeName, RangeAttack>();

    private void Awake()
    {
        RangeAttack[] range = GetComponentsInChildren<RangeAttack>();
        foreach (var attack in range)
        {
            rangeAttacks.Add(attack.attackName, attack);
        }

        MeleeAttack[] melee = GetComponentsInChildren<MeleeAttack>();
        foreach (var attack in melee)
        {
            meleeAttacks.Add(attack.attackName, attack);
        }
    }

    public MeleeAttack GetAttack(MeleeName attackName)
    {
        MeleeAttack attack = meleeAttacks[attackName];
        return attack;
    }

    public RangeAttack GetAttack(RangeName attackName)
    {
        RangeAttack attack = rangeAttacks[attackName];
        return attack;
    }
}

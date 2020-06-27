using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedArmor : Armor
{
    public float speedBuff;
    public float speedTimer;
    public PlayerMovement movement;

    public override IEnumerator ExecuteAction(Action onFinish)
    {
        movement.ModifySpeed(speedBuff);
        yield return new WaitForSeconds(speedTimer);
        movement.ResetSpeed();
        float remainingTimer = actionCooldown - speedTimer;
        yield return new WaitForSeconds(remainingTimer);
        onFinish?.Invoke();
    }
}

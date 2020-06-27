using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    public PlayerArmorDisplay display;
    public ArmorPool pool;
    public ArmorName defaultArmor;
    private Armor currentArmor;
    private int armorValue;
    private bool canAct = true;

    private void Start()
    {
        ModifyArmor(defaultArmor);
        InputManager.onArmorAction += ArmorActionHandler;
        PlayerCollision.onArmorLoot += ArmorLootHandler;
    }

    private void OnDestroy()
    {
        InputManager.onArmorAction -= ArmorActionHandler;
        PlayerCollision.onArmorLoot -= ArmorLootHandler;
    }

    private void ArmorLootHandler(ArmorName obj)
    {
        ModifyArmor(obj);
    }

    private void ArmorActionHandler()
    {
        if (canAct)
        {
            canAct = false;
            display.DisplayUsableArmor(Color.red);
            StartCoroutine(currentArmor.ExecuteAction(() =>
             {
                 canAct = true;
                 display.DisplayUsableArmor(Color.blue);
             }));
        }
    }

    public void ModifyArmor(ArmorName newArmor)
    {
        currentArmor = pool.Pool[newArmor];
        armorValue = currentArmor.armorValue;
        display.DisplayArmor(newArmor);
        display.DisplayDurability(armorValue);
    }

    public void CalculateDamage(int damageTaken, out int remainingDamage)
    {
        remainingDamage = 0;
        armorValue -= damageTaken;
        display.DisplayDurability(armorValue);
        if (armorValue <= 0)
        {
            remainingDamage = Mathf.Abs(armorValue);
            ModifyArmor(ArmorName.noArmor);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWeaponsDisplay : MonoBehaviour
{
    public TextMeshProUGUI meleeWeapon, meleeAmmo, rangeWeapon, rangeAmmo;
    public PlayerAttack attack;

    private void Update()
    {
        meleeWeapon.text = attack.currentMelee.attackName.ToString();
        rangeWeapon.text = attack.currentRange.attackName.ToString();

        string meleeAmmoText = attack.meleeAmmo > 0 ? attack.meleeAmmo.ToString() : "Infinite";
        meleeAmmo.text = meleeAmmoText;
        string rangeAmmoText = attack.rangeAmmo > 0 ? attack.rangeAmmo.ToString() : "Infinite";
        rangeAmmo.text = rangeAmmoText;
    }
}

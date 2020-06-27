using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArmorDisplay : MonoBehaviour
{
    public TextMeshProUGUI armorName, armorDurability;
    public Image usableArmor;

    public void DisplayArmor(ArmorName newArmor)
    {
        armorName.text = newArmor.ToString();
    }
    public void DisplayDurability(int durability)
    {
        armorDurability.text = durability.ToString();
    }

    public void DisplayUsableArmor(Color newColor)
    {
        usableArmor.color = newColor;
    }


}

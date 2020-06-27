using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    public void DisplayHealth(int currentHealth, int maxHealth)
    {
        string newString = currentHealth.ToString() + " / " + maxHealth.ToString();
        healthText.text = newString;
    }
}

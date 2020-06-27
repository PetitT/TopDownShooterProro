using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnnemyHealthDisplay : MonoBehaviour
{
    public TextMeshPro text;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        string newString = currentHealth.ToString() + " / " + maxHealth.ToString();
        text.text = newString;
    }

    private void Update()
    {
        text.transform.LookAt(cam.transform.position);
        text.transform.Rotate(Vector3.up, 180);
    }
}

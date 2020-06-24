using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifetime = 10f;
    private float remainingLifetime;

    private void OnEnable()
    {
        remainingLifetime = lifetime;
    }

    void Update()
    {
        remainingLifetime -= Time.deltaTime;
        if (remainingLifetime <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}

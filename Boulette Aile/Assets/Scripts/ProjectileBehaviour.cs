using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float projectileSpeed;

    private void Update()
    {
        gameObject.transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
}

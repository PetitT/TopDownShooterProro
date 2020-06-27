using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCancel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (other.GetComponent<ProjectileAllegiance>().allegiance == Allegiance.ennemy)
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBouncer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if(other.GetComponent<ProjectileAllegiance>().allegiance == Allegiance.ennemy)
            {
                other.gameObject.transform.forward = -other.gameObject.transform.forward;
                other.GetComponent<ProjectileAllegiance>().allegiance = Allegiance.allied;
            }
        }
    }
}

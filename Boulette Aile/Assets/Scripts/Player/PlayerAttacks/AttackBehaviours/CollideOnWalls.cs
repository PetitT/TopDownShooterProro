using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideOnWalls : MonoBehaviour
{
    public LayerMask obstacleMask;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
        }
    }
}

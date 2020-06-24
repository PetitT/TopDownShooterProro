using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public GameObject body;
    public LayerMask groundMask;
    private float bodyY;
    private Camera cam;

    private void Start()
    {
        bodyY = body.transform.position.y;
        cam = Camera.main;
    }

    private void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray,out hit, Mathf.Infinity, groundMask);
        Vector3 hitPos = hit.point;
        Vector3 target = new Vector3(hitPos.x, bodyY, hitPos.z);
        body.transform.LookAt(target);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera cam;
    public GameObject player;
    private Vector3 baseCamPos;
    private Vector2 center = new Vector2(0.5f, 0.5f);
    public float blendForce;

    private void Start()
    {
        cam = Camera.main;
        cam.gameObject.transform.LookAt(player.transform);
        baseCamPos = cam.transform.localPosition;
    }

    private void Update()
    {
        GetMousePos();
    }

    private void GetMousePos()
    {
        Vector2 viewportMousePos = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector2 difference = center - viewportMousePos;
        cam.transform.localPosition = new Vector3(baseCamPos.x - difference.x * blendForce, baseCamPos.y, baseCamPos.z - difference.y * blendForce);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMoving : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

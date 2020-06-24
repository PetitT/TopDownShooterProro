using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public CharacterController controller;
    public LayerMask ennemyLayer;
    Vector3 movement;

    int numberOfHits = 0;

    private void Update()
    {
        GetInputs();
        Move();
    }


    private void GetInputs()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Z = Input.GetAxisRaw("Vertical");

        movement = new Vector3(X, 0, Z);
    }

    private void Move()
    {
        controller.Move(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            numberOfHits++;
            Debug.Log(numberOfHits);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float defaultSpeed;
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = defaultSpeed;
        InputManager.onMoveInput += MoveHandler;
    }

    private void OnDestroy()
    {
        InputManager.onMoveInput -= MoveHandler;
    }

    private void MoveHandler(Vector2 movement)
    {
        movement = movement.normalized;
        Vector3 newMovement = new Vector3(movement.x, 0, movement.y);
        controller.Move(newMovement * currentSpeed * Time.deltaTime);
    }

    public void ModifySpeed(float newSpeed)
    {
        currentSpeed += newSpeed;
    }

    public void ResetSpeed()
    {
        currentSpeed = defaultSpeed;
    }
}

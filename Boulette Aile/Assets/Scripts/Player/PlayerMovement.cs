using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;

    private void Start()
    {
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
        controller.Move(newMovement * speed * Time.deltaTime);
    }
}

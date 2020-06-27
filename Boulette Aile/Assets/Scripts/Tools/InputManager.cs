using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action<Vector2> onMoveInput;
    public static event Action onMeleeAttack;
    public static event Action onRangeAttack;
    public static event Action onArmorAction;

    private void Update()
    {
        GetMoveInput();
        GetMouseInput();
        GetArmorInput();
    }

    private void GetMoveInput()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Z = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(X, Z);
        onMoveInput?.Invoke(movement);
    }

    private void GetMouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            onMeleeAttack?.Invoke();
        }
        if (Input.GetMouseButton(1))
        {
            onRangeAttack?.Invoke();
        }
    }

    private void GetArmorInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            onArmorAction?.Invoke();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode Move = KeyCode.Space;
    private const KeyCode Attack = KeyCode.C;

    public event Action Moved;
    public event Action Attacked;

    private void Update()
    {
        if (Input.GetKeyDown(Move))
        {
            Moved?.Invoke();
        }
        if (Input.GetKeyUp(Attack))
        {
            Attacked?.Invoke();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveStep;

    public void MoveInDirection(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        transform.Translate(moveStep * Time.fixedDeltaTime * movement.normalized);
    }
}

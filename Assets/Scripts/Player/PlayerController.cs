using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] KeyCode firePrimaryKey;
    [SerializeField] KeyCode upKey, downKey, leftKey, rightKey;

    void FixedUpdate()
    {
        if (Input.GetKey(upKey))
            MoveInDirection(Vector3.up);
        if (Input.GetKey(downKey))
            MoveInDirection(Vector3.down);
        if (Input.GetKey(leftKey))
            MoveInDirection(Vector3.left);
        if (Input.GetKey(rightKey))
            MoveInDirection(Vector3.right);
    }

    void MoveInDirection(Vector3 dir) => transform.Translate(moveSpeed * Time.fixedDeltaTime * dir.normalized);
}

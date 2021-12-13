using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 moveDirection;

    private void Update()
    {
       transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, moveDirection.x == -1 ? 0 : 180, 0);
    }

    public void Setup(float moveSpeed, Vector2 direction)
    {
        moveDirection = direction;
        this.moveSpeed = moveSpeed;
    }
}

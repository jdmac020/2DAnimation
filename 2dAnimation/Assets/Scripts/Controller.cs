using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour, IMovements
{
    public Rigidbody2D RigidBody { get; set; }
    public bool IsFacingRight { get; private set; } = true;
    public float MoveSpeed = .1f;

    public Vector2 LeftMovement()
    {
        if (IsFacingRight) IsFacingRight = false;

        return new Vector2(transform.position.x - MoveSpeed, transform.position.y);
    }

    public Vector2 RightMovement()
    {
        if (!IsFacingRight) IsFacingRight = true;

        return new Vector2(transform.position.x + MoveSpeed, transform.position.y);
    }

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }
}

﻿using Core;
using static Core.GlobalValues;
using UnityEngine;

public class Controller : MonoBehaviour, IMovements
{
    public Rigidbody2D RigidBody { get; set; }
    public Animator Animator { get; set; }
    public bool IsFacingRight { get; private set; } = true;
    public bool IsWalking { get; private set; }
    public float MoveSpeed = .1f;

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    public Vector2 LeftMovement()
    {
        if (IsFacingRight)
        {
            Flip();
        }

        return new Vector2(transform.position.x - MoveSpeed, transform.position.y);
    }

    public Vector2 RightMovement()
    {
        if (!IsFacingRight)
        {
            Flip();
        }

        return new Vector2(transform.position.x + MoveSpeed, transform.position.y);
    }

    private void Flip()
    {
        var currentScale = transform.localScale;
        transform.localScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);
        IsFacingRight = !IsFacingRight;
    }


    private void FixedUpdate()
    {
        var horizontalInput = Input.GetAxis(HORIZONTAL);

        IsWalking = true;
        Debug.Log($"Inside Fixed Update IsWalking Is {IsWalking}");

        if (horizontalInput != 0)
        {
            IsWalking = true;
        }
        else
        {
            IsWalking = false;
        }

        if (MovingRight(horizontalInput))
        {
            RigidBody.MovePosition(RightMovement());
        }
        else if (MovingLeft(horizontalInput))
        {
            RigidBody.MovePosition(LeftMovement());
        }

        Animator.SetFloat("move", Mathf.Abs(horizontalInput));
    }

    private bool MovingRight(float input)
    {
        return input > AXIS_MIN;
    }

    private bool MovingLeft(float input)
    {
        return input < -AXIS_MIN;
    }
}

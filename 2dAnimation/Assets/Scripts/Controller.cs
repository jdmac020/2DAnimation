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

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            RigidBody.MovePosition(LeftMovement());
        }
        else if (Input.GetAxis("Horizontal") > 0.1f)
        {
            RigidBody.MovePosition(RightMovement());
        }
    }
}

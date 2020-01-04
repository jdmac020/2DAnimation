using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour, IMovements
{
    public Rigidbody2D RigidBody { get; set; }
    public bool IsFacingRight { get; private set; } = true;

    public void MoveLeft()
    {
        if (IsFacingRight) IsFacingRight = false;
    }

    public void MoveRight()
    {
        if (!IsFacingRight) IsFacingRight = true;
    }

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }
}

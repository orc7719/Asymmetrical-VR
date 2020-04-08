using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour
{
    Vector2 targetVelocity;
    float moveSpeed = 0.5f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 move = Vector2.zero;

        GamePadState state = GamePad.GetState(0);

        move.x = -state.ThumbSticks.Left.X;
        move.y = state.ThumbSticks.Left.Y;

        targetVelocity = move * moveSpeed;
        rb.velocity = targetVelocity;
    }
}

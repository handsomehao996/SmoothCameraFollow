using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator ani;
    public SpriteRenderer spriteRenderer;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private void Update()
    {
        float horMove = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(horMove, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.x > 0.1)
        {
            spriteRenderer.flipX = false;
        }
        if(rb.velocity.x < -0.1)
        {
            spriteRenderer.flipX = true;
        }

        ani.SetFloat("VelocityXabs", Mathf.Abs(rb.velocity.x));
        ani.SetFloat("VelocityYabs", Mathf.Abs(rb.velocity.y));
        ani.SetFloat("VelocityY", rb.velocity.y);
    }
}

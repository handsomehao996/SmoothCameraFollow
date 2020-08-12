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

    public bool onFloor;
    public float radius = 0.2f;
    public float distance = 1;
    public LayerMask layerMask;

    public enum PlayerState { Idle, Hurt}
    public PlayerState playerState;

    public float hurtWaitTime = 0.5f;

    private void Update()
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                Move();
                UpdateAnimate();
                CheckAround();
                break;
            case PlayerState.Hurt:
                Hurt();
                break;
        }
    }

    void Move()
    {
        float horMove = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(horMove, rb.velocity.y);

        if (onFloor)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    void UpdateAnimate()
    {
        if (rb.velocity.x > 0.1)
        {
            spriteRenderer.flipX = false;
        }
        else if (rb.velocity.x < -0.1)
        {
            spriteRenderer.flipX = true;
        }
        ani.SetFloat("VelocityXabs", Mathf.Abs(rb.velocity.x));
        ani.SetFloat("VelocityYabs", Mathf.Abs(rb.velocity.y));
        ani.SetFloat("VelocityY", rb.velocity.y);
    }

    void CheckAround()
    {
        Vector2 origin = transform.position;
        Vector2 direction = -transform.up;
        RaycastHit2D hit = Physics2D.CircleCast(origin, radius, direction, distance, layerMask);
        if(hit.collider != null)
        {
            onFloor = true;
        }
        else
        {
            onFloor = false;
        }
    }

    void Hurt()
    {
        StartCoroutine(HurtWait());
    }

    IEnumerator HurtWait()
    {
        yield return new WaitForSeconds(hurtWaitTime);
        playerState = PlayerState.Idle;
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 origin = transform.position;
        Vector2 direction = -transform.up;
        Vector3 center = origin + direction * distance;
        Gizmos.DrawSphere(center, radius);
    }
}

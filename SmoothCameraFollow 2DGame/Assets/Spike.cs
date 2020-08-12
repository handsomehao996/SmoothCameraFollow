using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Spike : MonoBehaviour
{
    public float horMove = 5f;
    public float upMove = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerController>().playerState = PlayerController.PlayerState.Hurt;

            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            playerRb.velocity = Vector2.zero;

            float moveX = 0;
            bool playerFlipX = collision.collider.GetComponent<SpriteRenderer>().flipX;
            if (playerFlipX)
            {
                moveX = horMove;
            }
            else
            {
                moveX = -horMove;
            }
            playerRb.velocity = new Vector2(moveX, upMove);
        }
    }
}

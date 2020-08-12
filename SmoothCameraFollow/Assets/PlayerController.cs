using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;

    public float jumpForce = 10f;

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        Vector3 moveVec = Vector3.right * hor;
        rb.MovePosition(rb.position + moveVec * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

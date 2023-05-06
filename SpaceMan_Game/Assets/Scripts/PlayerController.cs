using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* -- variables -- */

    //public
    public float jumpForce = 8f;
    public LayerMask groundMask;
    //private
    private Rigidbody2D rb;
    private Animator animator;
    private bool isAlive = true;
    private bool isOnTheGround = true;


    /* -- core methods -- */

    void Start()
    {
        animator.SetBool("isAlive", isAlive);
        animator.SetBool("isOnTheGround", isOnTheGround);
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleJump();
        HandleOnTheGround();
        HandleVelocityY();
        DrawDebugRay();
    }


    /* -- custom methods -- */

    bool IsTouchingTheGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundMask);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (IsTouchingTheGround())
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    void HandleOnTheGround()
    {
        bool newIsOnTheGround = IsTouchingTheGround();
        if (isOnTheGround != newIsOnTheGround)
        {
            isOnTheGround = newIsOnTheGround;
            animator.SetBool("isOnTheGround", isOnTheGround);
        }
    }

    void HandleVelocityY()
    {
        float velocityY = rb.velocity.y;
        animator.SetFloat("velocityY", velocityY);

        if (!IsTouchingTheGround() && velocityY <= 0.1f)
        {
            animator.SetFloat("velocityY", 0f);
        }
    }

    void DrawDebugRay()
    {
        Debug.DrawRay(transform.position, Vector2.down * 1.5f, Color.red);
    }
}

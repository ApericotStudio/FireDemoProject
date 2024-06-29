using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;
    private Vector2 velocity = Vector2.zero;
    private Vector2 moveInput;
    private PlayerControls controls;
    private float horizontal;
    private bool collidingPlayer;
    private bool facingRight;
    public PlayerInputChecker inputChecker;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float boostForce = 1f;
    [SerializeField] private float gravity = -9.81f;

    public bool FacingRight { get => facingRight; set => facingRight = value; }
    public float BoostForce { get => boostForce; set => boostForce = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public bool CollidingPlayer { get => collidingPlayer; set => collidingPlayer = value; }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collidingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collidingPlayer = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        // Check and update facing direction based on movement
        if (horizontal > 0)
        {
            // Moving right
            facingRight = true;
        }
        else if (horizontal < 0)
        {

            facingRight = false;
        }
    }

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void lastDirection()
    {

    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        horizontal = ctx.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(ctx.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (collidingPlayer && inputChecker.PressedButton)
        {
            rb.velocity = new Vector2(rb.velocity.x, boostForce);
        }
    }
}

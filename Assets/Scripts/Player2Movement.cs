using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;
    private Vector2 velocity = Vector2.zero;
    private Vector2 moveInput;
    private PlayerControls controls;
    private float horizontal;
    private bool collidingPlayer;
    private SpriteRenderer sprite;
    private Color colorA;
    private Color colorB;

    public PlayerInputChecker inputChecker;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject image;


    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float gravity = 0f;

    public bool CollidingPlayer { get => collidingPlayer; set => collidingPlayer = value; }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = image.GetComponent<SpriteRenderer>();
        colorA = Color.white;
        colorB = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveInput * moveSpeed;
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


    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        
    }
    public void ToggleColor()
    {
        if (sprite.color == colorA)
        {
            sprite.color = colorB;
        }
        else
        {
            sprite.color = colorA;
        }
    }
}

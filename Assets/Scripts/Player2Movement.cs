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

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float gravity = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Debug.Log(moveInput);
        moveInput = ctx.ReadValue<Vector2>();
    }
}

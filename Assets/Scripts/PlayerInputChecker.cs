using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputChecker : MonoBehaviour
{
    public InputActionAsset inputActions;
    public Player1Movement player1; 

    private InputAction player1FireAction;
    private InputAction player2FireAction;
    [SerializeField] private Rigidbody2D rb;

    [HideInInspector] private bool pressedButton;
    public bool MyProperty { get; set; }
    public bool PressedButton { get => pressedButton; set => pressedButton = value; }

    private void OnEnable()
    {
        var player1ActionMap = inputActions.FindActionMap("Player1");
        var player2ActionMap = inputActions.FindActionMap("Player2");

        // Get the fire actions
        player1FireAction = player1ActionMap.FindAction("Fire");
        player2FireAction = player2ActionMap.FindAction("Fire");

        player1FireAction.Enable();
        player2FireAction.Enable();
    }

    private void OnDisable()
    {
        player1FireAction.Disable();
        player2FireAction.Disable();
    }

    private void BoostPad()
    {
        rb.velocity = new Vector2(player1.BoostForce, rb.velocity.y);
    }

    private void JumpPad()
    {
        rb.velocity = new Vector2(rb.velocity.x, player1.JumpForce);
    }

    void Update()
    {
        bool player2FireHeld = player2FireAction.phase == InputActionPhase.Performed || player2FireAction.phase == InputActionPhase.Started;

        if (player1FireAction.triggered && player2FireHeld && player1.CollidingPlayer)
        {
            pressedButton = true;
            JumpPad();
        }
        else
        {
            pressedButton = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputChecker : MonoBehaviour
{
    public InputActionAsset inputActions;
    public Player1Movement player1;
    public Player2Movement player2;

    private InputAction player1FireAction;
    private float currentYVelocity;
    private InputAction player2FireAction;
    [SerializeField] private Rigidbody2D rb1;
    [SerializeField] private Rigidbody2D rb2;

    [HideInInspector] private bool pressedButton;
    public bool MyProperty { get; set; }
    public bool PressedButton { get => pressedButton; set => pressedButton = value; }
    public bool HasBoost { get => hasBoost; set => hasBoost = value; }
    public Vector2 BoostAmount { get => boostAmount; set => boostAmount = value; }

    private bool hasBoost;
    private bool GhostPlayer1 = false;


    private Vector2 boostAmount;

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
        float boostforce;
        if (player1.FacingRight == true)
        {
            boostforce = player1.BoostForce;
        }
        else
        {
            boostforce = player1.BoostForce * -1;
        }

        hasBoost = true;



        rb1.velocity = new Vector2(boostforce, currentYVelocity);
    }

    private void JumpPad()
    {
        rb1.velocity = new Vector2(rb1.velocity.x, player1.JumpForce);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) //Switch Button
        {
            GhostPlayer1 = !GhostPlayer1;
           
            player2.ToggleColor();
        }

        bool player2FireHeld = player2FireAction.phase == InputActionPhase.Performed || player2FireAction.phase == InputActionPhase.Started;

        if (player1FireAction.triggered && player2FireHeld && player1.CollidingPlayer)
        {
            pressedButton = true;
            currentYVelocity = rb1.velocity.y;

            if (GhostPlayer1)
            {
                BoostPad();
            }
            else
            {
                JumpPad();
            }
        }
        else
        {
            pressedButton = false;
        }
    }
}

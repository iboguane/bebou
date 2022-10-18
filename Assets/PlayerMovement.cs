using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private InputAction Movement;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;

    private void Awake()
    {
        playerInputs = new();
    }

    private void OnEnable()
    {
        Movement = playerInputs.Player.Movement;
        Movement?.Enable();
    }

    private void OnDisable()
    {
        Movement?.Disable();
    }

    private void FixedUpdate()
    {
        rb.velocity = Movement.ReadValue<Vector2>() * movementSpeed * Time.fixedDeltaTime;
    }

}

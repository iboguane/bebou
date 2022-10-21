using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private InputAction movement;
    private InputAction dash;
    private Vector3 velocity = Vector3.zero;
    private Cooldowns cdDash;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Image dashImage;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashCooldown;

    [SerializeField] UnityEvent _onDash;

    private void Awake()
    {
        playerInputs = new();
        cdDash = new Cooldowns(dashCooldown);
    }

    private void OnEnable()
    {
        movement = playerInputs.Player.Movement;
        movement?.Enable();
        dash = playerInputs.Player.Dash;
        dash?.Enable();
        dash.performed += OnDash;
    }

    private void OnDisable()
    {
        movement?.Disable();
        dash?.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = movement.ReadValue<Vector2>() * movementSpeed * Time.fixedDeltaTime;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        cdDash.DecreaseCD(Time.fixedDeltaTime);
        UpdateDashCD();
    }

    private void UpdateDashCD()
    {
        if (cdDash.isFinished && dashImage.fillAmount == 1) return;
        dashImage.fillAmount = 1 - (cdDash.currentCD / dashCooldown);
    }

    private void OnDash(InputAction.CallbackContext ctx) => Dash();

    private void Dash()
    {
        if (!cdDash.isFinished) return;

        _onDash.Invoke();
        cdDash.ResetCD();
        rb.AddForce(movement.ReadValue<Vector2>() * dashForce, ForceMode2D.Impulse);
    }
}

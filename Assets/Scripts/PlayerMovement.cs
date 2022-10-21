using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private InputAction movement;
    private InputAction dash;
    private Vector3 velocity = Vector3.zero;
    private Cooldowns cdDash;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Image dashImage;
    [SerializeField] private Transform spriteR;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashCooldown;

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
        Vector2 direction = movement.ReadValue<Vector2>();
        if (direction != Vector2.zero)
        {
            spriteR.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180);
        }
        Vector2 targetVelocity = direction * movementSpeed * Time.fixedDeltaTime;
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
        cdDash.ResetCD();
        rb.AddForce(movement.ReadValue<Vector2>() * dashForce, ForceMode2D.Impulse);
    }
}

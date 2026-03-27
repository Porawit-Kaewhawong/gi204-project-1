using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;

    Rigidbody rb;
    InputAction moveAction;
    InputAction jumpAction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        var rawInput = moveAction.ReadValue<Vector2>();
        var clampInput = Vector2.ClampMagnitude(rawInput, 1f);

        transform.Translate(Vector3.right * clampInput * moveSpeed * Time.deltaTime);

        if (jumpAction.inProgress && rb.linearVelocity.y < 6f)
        {
            float mass = rb.mass;
            Vector3 acceleration = Vector3.up * 5f;

            Vector3 force = mass * acceleration;

            rb.AddForce(force, ForceMode.Force);
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;

    Rigidbody rb;
    InputAction moveAction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        var rawInput = moveAction.ReadValue<Vector2>();
        var clampInput = Vector2.ClampMagnitude(rawInput, 1f);

        rb.AddForce(new Vector3(clampInput.x, 0, clampInput.y) * moveSpeed, ForceMode.Acceleration);
    }
}

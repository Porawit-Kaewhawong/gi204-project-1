using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 10f;
    public float rotation = 1f;

    private Rigidbody rb;
    private InputAction moveAction;

    private FixedJoint joint;
    private GameObject attachedCrate;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ReleaseCrate();
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        var inputValue = moveAction.ReadValue<Vector2>();

        rb.AddForce(new Vector3(inputValue.x, inputValue.y, 0) * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (attachedCrate == null && collision.gameObject.CompareTag("Crate"))
        {
            attachedCrate = collision.gameObject;
            Rigidbody createRb = attachedCrate.GetComponent<Rigidbody>();

            if (createRb != null)
            {
                joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = createRb;

                Debug.Log("Crate Attached");
            }
        }
    }

    void ReleaseCrate()
    {
        if (joint.connectedBody != null)
        {
            Destroy(joint);
            attachedCrate = null;

            Debug.Log("Crate Released");
        }
    }
}

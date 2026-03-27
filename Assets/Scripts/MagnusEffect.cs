
using System.Threading;
using UnityEngine;

public class MagnusEffect : MonoBehaviour
{
    public float magnusCoefficient = 0.1f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.linearVelocity = transform.right * 20f;
        rb.angularVelocity = Vector3.forward * 40f;

        Destroy(gameObject, 5f);
    }

    void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;
        Vector3 angularVelocity = rb.angularVelocity;

        Vector3 magnusForce = Vector3.Cross(angularVelocity, velocity);

        rb.AddForce(magnusForce * magnusCoefficient);
    }
}

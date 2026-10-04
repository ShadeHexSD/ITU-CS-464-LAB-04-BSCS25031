using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 6f;

    Rigidbody rb;
    bool isGrounded;
    bool jumpQueued;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Prevent the capsule from falling/rolling over
        rb.freezeRotation = true;

        // Makes Rigidbody movement look smoother
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        // Detect jump input
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumpQueued = true;
        }
    }

    void FixedUpdate()
    {
        // Get WASD / Arrow Key movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        // Prevent diagonal movement from being faster
        move = Vector3.ClampMagnitude(move, 1f) * speed;

        // Apply horizontal movement while keeping vertical velocity
        rb.linearVelocity = new Vector3(
            move.x,
            rb.linearVelocity.y,
            move.z
        );

        // Jump
        if (jumpQueued)
        {
            rb.AddForce(
                Vector3.up * jumpForce,
                ForceMode.Impulse
            );

            jumpQueued = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Check whether we're standing on a surface
        if (collision.GetContact(0).normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
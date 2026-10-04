using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Transform spawnLocation;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            // Stop the player's current movement
            playerRb.linearVelocity = Vector3.zero;

            // Teleport player to spawn
            collision.transform.position = spawnLocation.position;
        }
    }
}
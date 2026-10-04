using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyManager.instance.EnemyDied();
            Destroy(gameObject);
        }
    }
}
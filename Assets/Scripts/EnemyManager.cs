using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField] int enemiesLeft;
    [SerializeField] GameObject finalLock;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        enemiesLeft = FindObjectsByType<Enemy>(
            FindObjectsSortMode.None
        ).Length;
    }

    public void EnemyDied()
    {
        enemiesLeft--;

        Debug.Log("Enemies Left: " + enemiesLeft);

        if (enemiesLeft <= 0)
        {
            BreakLock();
        }
    }

    void BreakLock()
    {
        Destroy(finalLock);
    }
}
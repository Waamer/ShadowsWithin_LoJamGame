using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    private HealthController healthController;
    private EnemyManager enemyManager;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.OnDied.AddListener(OnEnemyDeath);
        }

        // Find the EnemyManager in the scene
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    private void OnEnemyDeath()
    {
        // Notify the EnemyManager that an enemy has died
        if (enemyManager != null)
        {
            enemyManager.DecreaseEnemyCount();
        }

        // Destroy the enemy game object when it dies
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (healthController != null)
        {
            healthController.OnDied.RemoveListener(OnEnemyDeath);
        }
    }
}

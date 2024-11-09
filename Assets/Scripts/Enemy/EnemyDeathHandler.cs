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
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    private void OnEnemyDeath()
    {
        if (enemyManager != null)
        {
            enemyManager.DecreaseEnemyCount();
        }

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

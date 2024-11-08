using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    private HealthController healthController;
    [SerializeField] private UIManager _uiManager; // Reference to the UIManager

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.OnDied.AddListener(OnEnemyDeath); // Subscribe to the OnDied event
        }
    }

    private void OnEnemyDeath()
    {
        // Notify the UIManager that an enemy has died
        if (_uiManager != null)
        {
            _uiManager.DecrementEnemyCount();  // Decrease the count in the UI
        }

        // Destroy the enemy game object when it dies
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the OnDied event to avoid memory leaks
        if (healthController != null)
        {
            healthController.OnDied.RemoveListener(OnEnemyDeath);
        }
    }
}

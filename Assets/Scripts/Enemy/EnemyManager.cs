using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int remainingEnemies;  // Set this in the inspector
    [SerializeField] private UIManager uiManager;  // Reference to the UIManager
    [SerializeField] private LevelLoader levelLoader;  // Reference to the LevelLoader to switch levels

    private void Start()
    {
        if (uiManager != null)
        {
            uiManager.UpdateEnemyCount(remainingEnemies);  // Initialize the UI with the initial enemy count
        }
    }

    // Decrease the enemy count when an enemy is destroyed
    public void DecreaseEnemyCount()
    {
        remainingEnemies--;
        if (uiManager != null)
        {
            uiManager.UpdateEnemyCount(remainingEnemies);  // Update the UI when an enemy is destroyed
        }

        // If no enemies are left, load the next level
        if (remainingEnemies <= 0)
        {
            if (levelLoader != null)
            {
                levelLoader.LoadNextLevel();  // Switch the level when all enemies are defeated
            }
        }
    }

    // Expose a method to set the initial enemy count (called from the EnemySpawn)
    public void SetInitialEnemyCount(int count)
    {
        remainingEnemies = count;
        if (uiManager != null)
        {
            uiManager.UpdateEnemyCount(remainingEnemies);  // Initialize the UI with the total enemy count
        }
    }
}

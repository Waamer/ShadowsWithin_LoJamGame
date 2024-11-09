using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int remainingEnemies; 
    [SerializeField] private UIManager uiManager;  
    [SerializeField] private LevelLoader levelLoader;  

    private void Start()
    {
        if (uiManager != null)
        {
            uiManager.UpdateEnemyCount(remainingEnemies); 
        }
    }
    
    public void DecreaseEnemyCount()
    {
        remainingEnemies--;
        if (uiManager != null)
        {
            uiManager.UpdateEnemyCount(remainingEnemies);  
        }

        if (remainingEnemies <= 0)
        {
            if (levelLoader != null)
            {
                levelLoader.LoadNextLevel();  
            }
        }
    }

    public void SetInitialEnemyCount(int count)
    {
        remainingEnemies = count;
        if (uiManager != null)
        {
            uiManager.UpdateEnemyCount(remainingEnemies); 
        }
    }
}

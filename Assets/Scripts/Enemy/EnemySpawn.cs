using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _timeUntilSpawn;
    [SerializeField] private int _maxSpawnCount;
    [SerializeField] private UIManager _uiManager;  // Reference to the UIManager

    private float theTime;
    private int _currentSpawnCount = 0;

    void Start()
    {
        theTime = _timeUntilSpawn;
        // Ensure UIManager reference is assigned
        if (_uiManager != null)
        {
            _uiManager.UpdateEnemyCount(_maxSpawnCount);  // Initialize the UI with the total number of enemies
        }
    }

    void Update()
    {
        if (_currentSpawnCount >= _maxSpawnCount)
        {
            return;
        }

        theTime -= Time.deltaTime;

        if (theTime <= 0)
        {
            GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            _currentSpawnCount++;
            theTime = _timeUntilSpawn;

            if (_uiManager != null)
            {
                _uiManager.IncrementEnemyCount();  // Update the UI with the new enemy count
            }
        }
    }
}

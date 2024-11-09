using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _timeUntilSpawn;
    [SerializeField] private int _maxSpawnCount;

    private float theTime;
    private int _currentSpawnCount = 0;

    void Start()
    {
        theTime = _timeUntilSpawn;
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
        }
    }
}

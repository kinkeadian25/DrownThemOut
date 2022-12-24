using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Action WaveCompleted;

    [Header("Spawner Settings")]
    [SerializeField] private SpawnerType spawnerType= SpawnerType.Fixed;
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private float waveDelay = 1f;
    [Header("Fixed Time")]
    [SerializeField] private float spawnDelay;

    [Header("Random Time")]
    [SerializeField] private float minRandDelay;
    [SerializeField] private float maxRandDelay;

    [Header("Enemy Settings")]
    [SerializeField] private ObjectPooler objectPoolerWave1;
    [SerializeField] private ObjectPooler objectPoolerWave2;
    [SerializeField] private ObjectPooler objectPoolerWave3;
    [SerializeField] private ObjectPooler objectPoolerWave4;
    [SerializeField] private ObjectPooler objectPoolerWave5;
    [SerializeField] private ObjectPooler objectPoolerWave6;
    [SerializeField] private ObjectPooler objectPoolerWave7;
    [SerializeField] private ObjectPooler objectPoolerWave8;
    [SerializeField] private ObjectPooler objectPoolerWave9;
    [SerializeField] private ObjectPooler objectPoolerWave10;

    private float _spawnTimer;
    private float _enemiesSpawned;
    private int _enemiesRemaining;
    private ObjectPooler _objectPooler;
    private Waypoint _waypoint;

    private bool _waveCompleted;

    void Start() 
    {
        _objectPooler = GetComponent<ObjectPooler>();
        _waypoint = GetComponent<Waypoint>();
        _enemiesRemaining = enemyCount; 
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0)
        {
            _spawnTimer = GetSpawnDelay();
            if(_enemiesSpawned < enemyCount)
            {
                _enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject newInstance = GetPooler().GetInstanceFromPooler();
        Enemy enemy = newInstance.GetComponent<Enemy>();
        enemy.Waypoint = _waypoint;
        enemy.ResetEnemy();

        enemy.transform.localPosition = transform.position;

        newInstance.SetActive(true);
    }

    private float GetSpawnDelay()
    {
        float delay = 0f;
        if (spawnerType == SpawnerType.Fixed)
        {
            delay = spawnDelay;
        }
        else if (spawnerType == SpawnerType.Random)
        {
            delay = GetRandomDelay();
        }
        return delay;
    }

    private float GetRandomDelay()
    {
        return UnityEngine.Random.Range(minRandDelay, maxRandDelay);
    }

    private IEnumerator NextWave()
    {
        yield return new WaitForSeconds(waveDelay);
        _enemiesSpawned = 0;
        _enemiesRemaining = enemyCount;    
        _spawnTimer = 0;
        _waveCompleted = false;
    }

    private void EnemyRecord()
    {
        _enemiesRemaining--;
        if (_enemiesRemaining <= 0 && !_waveCompleted)
        {
            _waveCompleted = true;
            WaveCompleted?.Invoke();
            StartCoroutine(NextWave());
        }
    }

    private void OnEnable() 
    {
        Enemy.OnEnemyReachedEnd += EnemyRecord;
        EnemyHealth.OnEnemyDied += EnemyRecord;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyReachedEnd -= EnemyRecord;
        EnemyHealth.OnEnemyDied -= EnemyRecord;
    }

    private ObjectPooler GetPooler()
    {
        ObjectPooler pooler = null;
        switch (LevelManager.Instance.CurrentWave)
        {
            case 1:
                pooler = objectPoolerWave1;
                break;
            case 2:
                pooler = objectPoolerWave2;
                break;
            case 3:
                pooler = objectPoolerWave3;
                break;
            case 4:
                pooler = objectPoolerWave4;
                break;
            case 5:
                pooler = objectPoolerWave5;
                break;
            case 6:
                pooler = objectPoolerWave6;
                break;
            case 7:
                pooler = objectPoolerWave7;
                break;
            case 8:
                pooler = objectPoolerWave8;
                break;
            case 9:
                pooler = objectPoolerWave9;
                break;
            case 10:
                pooler = objectPoolerWave10;
                break;
            default:
                pooler = objectPoolerWave1;
                break;
        }
        return pooler;
    }
}

public enum SpawnerType{ Fixed, Random }

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Action OnEnemyReachedEnd;
    [SerializeField] private float moveSpeed = 1f;
    public Waypoint Waypoint { get; set; }
    private int _currentWaypointIndex;
    public EnemyHealth EnemyHealth { get; set; }
    private EnemyChangeColor _enemyChangeColor;

    private EnemyHealth _enemyHealth;
    private SpriteRenderer _spriteRenderer;

    public Vector3 CurrentPosition => Waypoint.GetWaypointPosition(_currentWaypointIndex);

    void Start()
    {
        EnemyHealth = GetComponent<EnemyHealth>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyChangeColor = GetComponent<EnemyChangeColor>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Waypoint = FindObjectOfType<Waypoint>();
        _currentWaypointIndex = 0;
    }

    private void Update()
    {
        Move();
        if (CurrentPositionReached())
        {
            UpdateCurrentPointIdx();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPosition, moveSpeed * Time.deltaTime);
    }

    private bool CurrentPositionReached()
    {
        float distanceToNext = (transform.position - CurrentPosition).magnitude;
        return distanceToNext < 0.1f;
    }

    private void UpdateCurrentPointIdx()
    {
        int lastIndex = Waypoint.Points.Length - 1;
        if (_currentWaypointIndex < lastIndex)
        {
            _currentWaypointIndex++;
        }
        else
        {
            OnEnemyReachedEnd?.Invoke();
            ObjectPooler.ReturnToPooler(gameObject);
            _enemyHealth.ResetHealth();
            _spriteRenderer.color = _enemyChangeColor.ResetColor();
        }
    }
    public void ResetEnemy()
    {
        _currentWaypointIndex = 0;
    }
    
    
}

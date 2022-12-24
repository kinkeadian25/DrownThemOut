using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkler : MonoBehaviour
{
    [SerializeField] private float attackRange = 3f;

    public Enemy CurrentTarget { get; set; }

    private bool _gameStarted;
    private List<Enemy> _enemies;

    private void Start()
    {
        _gameStarted = true;
        _enemies = new List<Enemy>();
    }

    private void Update()
    {
        GetCurrentTarget();
        RotateToTarget();
    }

    private void GetCurrentTarget()
    {
        if (_enemies.Count <= 0)
        {
            CurrentTarget = null;
            return;
        }

        CurrentTarget = _enemies[0];
    }

    private void RotateToTarget()
    {
        if (CurrentTarget != null)
        {
            Vector2 direction = (Vector2)(CurrentTarget.transform.position - transform.position);
            transform.up = direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemies.Remove(enemy);
        }
    }

    private void OnDrawGizmos() 
    {
        if (!_gameStarted)
        {
            GetComponent<CircleCollider2D>().radius = attackRange;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

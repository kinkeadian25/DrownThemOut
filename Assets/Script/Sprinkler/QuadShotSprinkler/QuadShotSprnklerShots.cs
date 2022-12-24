using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadShotSprnklerShots : MonoBehaviour
{
    [SerializeField] private float damageDelay = 2f;
    [SerializeField] private float shotsSpread = 5f;
    [SerializeField] private float damage = .5f;
    private float _nextShotTime;

    private void Start()
    {
    }

    private void Update()
    {
        Rotate();
        if (Time.time > _nextShotTime)
        {
            DealDamage();
            _nextShotTime = Time.time + damageDelay;
        }
    }

    private void DealDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, shotsSpread);
        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                if (enemy.EnemyHealth.CurrentHealth > 0f)
                {
                    enemy.EnemyHealth.DealDamage(damage);
                }
            }
        }
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, 1);
    }

}


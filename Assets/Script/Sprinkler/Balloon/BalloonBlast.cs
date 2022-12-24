using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBlast : WaterShots
{
    public Vector2 Direction { get; set; }
    [SerializeField] private float expRadius = 1f;
    [SerializeField] GameObject balloonExplosion;

    protected override void Update()
    {
        ShootEnemy();
    }

    protected override void ShootEnemy()
    {
        Vector2 movement = Direction.normalized * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if(enemy.EnemyHealth.CurrentHealth > 0f)
            {
                enemy.EnemyHealth.DealDamage(damage);
                Explode();
            }

            ObjectPooler.ReturnToPooler(gameObject);
        }
        
        
    }

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, expRadius);
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
}

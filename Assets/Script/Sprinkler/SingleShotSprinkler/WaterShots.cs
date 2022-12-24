using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShots : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected float damage = 1f;
    public SprinklerShots Sprinkler { get; set; }
    protected Enemy _enemy;

    protected virtual void Update()
    {
        if(_enemy != null)
        {
            ShootEnemy();
            RotateToEnemy();
        }
    } 

    protected virtual void ShootEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, _enemy.transform.position, speed * Time.deltaTime);
        float distanceToNext = (_enemy.transform.position - transform.position).magnitude;
        if (distanceToNext < 0.5f)
        {
            _enemy.EnemyHealth.DealDamage(damage);
    
            Sprinkler.ReloadShots();
            ObjectPooler.ReturnToPooler(gameObject);
        }
    }

    private void RotateToEnemy()
    {
        Vector3 direction = _enemy.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, direction, transform.forward);
        transform.Rotate(0, 0, angle);
    }

    public void SetTarget(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void ResetShot()
    {
        _enemy = null;
        transform.localRotation = Quaternion.identity;
    }
    
}

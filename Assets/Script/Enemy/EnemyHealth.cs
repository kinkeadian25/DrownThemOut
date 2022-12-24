using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static Action OnEnemyDied;
    [SerializeField] private float _lifeToChangeColor2 = 2f;
    [SerializeField] private float _lifeToChangeColor1 = 1f;
    [SerializeField] private float initialHealth = 3f;
    private SpriteRenderer _spriteRenderer;
    EnemyChangeColor _enemyChangeColor;
    public float CurrentHealth { get; set; }
    private Enemy _enemy;

    void Start()
    {
        CurrentHealth = initialHealth;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyChangeColor = GetComponent<EnemyChangeColor>();
        _enemy = GetComponent<Enemy>();
    }

    public void DealDamage(float damage)
    {
        CurrentHealth -= damage;
        ColorManager();
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Death();
        }
    }

    public void ResetHealth()
    {
            CurrentHealth = initialHealth;
    }

    private void Death()
    {
        _spriteRenderer.color = _enemyChangeColor.ResetColor();
        OnEnemyDied?.Invoke();
        ObjectPooler.ReturnToPooler(gameObject);
        
        ResetHealth();
    }

    private void ColorManager()
    {
        if(CurrentHealth <= _lifeToChangeColor1)
        {
            _spriteRenderer.color = _enemyChangeColor.ChangeColor1();
        }
        else if(CurrentHealth <= _lifeToChangeColor2)
        {
            _spriteRenderer.color = _enemyChangeColor.ChangeColor2();
        }
    }
}

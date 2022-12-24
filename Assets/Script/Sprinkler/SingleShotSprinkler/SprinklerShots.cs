using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerShots : MonoBehaviour
{
    [SerializeField] protected Transform _shotSpawnPoint;
    [SerializeField] protected float _shotDelay = 5f;
    protected float _nextShotTime;
    protected ObjectPooler _objectPooler;
    private WaterShots _waterShot;
    protected Sprinkler _sprinkler;

    private void Start()
    {
        _objectPooler = GetComponent<ObjectPooler>();
        _sprinkler = GetComponent<Sprinkler>();

        LoadShot();
    }

    protected virtual void Update()
    {
        if (_waterShot == null)
        {
            LoadShot();
        }

        if (Time.time > _nextShotTime)
        {
            if (_sprinkler.CurrentTarget != null && _sprinkler.CurrentTarget.EnemyHealth.CurrentHealth > 0f)
            {
                _waterShot.transform.parent = null;
                _waterShot.SetTarget(_sprinkler.CurrentTarget);
            }

            _nextShotTime = Time.time + _shotDelay;
        }
    }

    protected virtual void LoadShot()
    {
        GameObject shot = _objectPooler.GetInstanceFromPooler();
        shot.transform.localPosition = _shotSpawnPoint.position;
        shot.transform.SetParent(_shotSpawnPoint);
        _waterShot = shot.GetComponent<WaterShots>();
        _waterShot.Sprinkler = this;
        _waterShot.ResetShot();
        shot.SetActive(true);
    }

    public void ReloadShots()
    {
        _waterShot = null;
    }
}
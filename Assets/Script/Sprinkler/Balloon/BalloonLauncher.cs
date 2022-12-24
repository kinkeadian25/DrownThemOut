using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonLauncher : SprinklerShots
{
    protected override void Update()
    {
        if (Time.time > _nextShotTime)
        {
            if(_sprinkler.CurrentTarget != null && _sprinkler.CurrentTarget.EnemyHealth.CurrentHealth > 0)
            {
                Vector3 directionToEnemy = _sprinkler.CurrentTarget.transform.position - transform.position;
                LaunchBalloon(directionToEnemy);
            }
            _nextShotTime = Time.time + _shotDelay;
        }
    }

    private void LaunchBalloon(Vector3 direction)
    {
        GameObject balloon = _objectPooler.GetInstanceFromPooler();
        balloon.transform.position = _shotSpawnPoint.position;

        BalloonBlast balloonScript = balloon.GetComponent<BalloonBlast>();
        balloonScript.Direction = direction;
        balloon.SetActive(true);    
    }
}

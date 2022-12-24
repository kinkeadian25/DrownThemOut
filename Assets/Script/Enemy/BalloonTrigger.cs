using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonTrigger : MonoBehaviour
{
    private ParticleSystem _particle;

    private void Start()
    {
        _particle = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
            emitParams.startLifetime = .5f;
            _particle.Emit(emitParams, 50);
        }
    }
}

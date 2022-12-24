using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private Animator anim;
    private GameObject _quadSprinkler = null;
    private GameObject _sprinkler = null;
    private GameObject _balloonLauncher = null;
    private bool _pickupAllowed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _quadSprinkler = GameObject.Find("Quad Sprayer") ?? null;
        _sprinkler = GameObject.Find("Single Sprinkler") ?? null;
        _balloonLauncher = GameObject.Find("BalloonLauncher") ?? null;
        _pickupAllowed = false;
    }

    private void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        _direction = new Vector2(directionX, directionY).normalized;

        Animate();

        if(_pickupAllowed && Input.GetKeyDown(KeyCode.E) && _sprinkler?.transform.position.x - transform.position.x < 1f && _sprinkler?.transform.position.y - transform.position.y < 1f && _sprinkler?.transform.position.x - transform.position.x > -1f && _sprinkler?.transform.position.y - transform.position.y > -1f)
        {
            _sprinkler?.transform.SetParent(gameObject.transform);
            _sprinkler.transform.position = Vector2.MoveTowards(_sprinkler.transform.position, transform.position, 0.3f);
        }
        else if(_pickupAllowed && Input.GetKeyDown(KeyCode.E) && _quadSprinkler?.transform.position.x - transform.position.x < 1f && _quadSprinkler?.transform.position.y - transform.position.y < 1f && _quadSprinkler?.transform.position.x - transform.position.x > -1f && _quadSprinkler?.transform.position.y - transform.position.y > -1f)
        {
            _quadSprinkler?.transform.SetParent(gameObject.transform);
            _quadSprinkler.transform.position = Vector2.MoveTowards(_quadSprinkler.transform.position, transform.position, 0.3f);
        }
        else if(_pickupAllowed && Input.GetKeyDown(KeyCode.E) && _balloonLauncher?.transform.position.x - transform.position.x < 1f && _balloonLauncher?.transform.position.y - transform.position.y < 1f && _balloonLauncher?.transform.position.x - transform.position.x > -1f && _balloonLauncher?.transform.position.y - transform.position.y > -1f)
        {
            _balloonLauncher?.transform.SetParent(gameObject.transform);
            _balloonLauncher.transform.position = Vector2.MoveTowards(_balloonLauncher.transform.position, transform.position, 0.3f);
        }

        if (_sprinkler?.transform.parent == gameObject.transform && Input.GetKeyDown(KeyCode.R))
        {
            _sprinkler?.transform.SetParent(null);
        }
        else if (_quadSprinkler?.transform.parent == gameObject.transform && Input.GetKeyDown(KeyCode.R))
        {
            _quadSprinkler?.transform.SetParent(null);
        }
        else if(_balloonLauncher?.transform.parent == gameObject.transform && Input.GetKeyDown(KeyCode.R))
        {
            _balloonLauncher?.transform.SetParent(null);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * speed, _direction.y * speed);
    }

    void Animate()
    {
        anim.SetFloat("AnimMoveX", _direction.x);
        anim.SetFloat("AnimMoveY", _direction.y);
    } 

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Sprinkler")
        {
            _pickupAllowed = true;
        }
        else if(other.gameObject.tag == "QuadSprinkler")
        {
            _pickupAllowed = true;
        }
        else if(other.gameObject.tag == "BalloonLauncher")
        {
            _pickupAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Sprinkler")
        {
            _pickupAllowed = false;
        }
        else if(other.gameObject.tag == "QuadSprinkler")
        {
            _pickupAllowed = false;
        }
        else if(other.gameObject.tag == "BalloonLauncher")
        {
            _pickupAllowed = false;
        }
    }      
}

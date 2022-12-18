using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject house;

    [SerializeField]
    public float speed = 0.1f;
    Vector2 movement;
    private bool isBouncing;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Move(enemy, house, speed));
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (!isBouncing) rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "House")
        {
            var magnitude = .5f;
            // calculate force vector
            var force = enemy.transform.position - house.transform.position;
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            rb.AddForce(force * magnitude);
        }
    }

    IEnumerator Move(GameObject enemy, GameObject house, float speed)
    {
        while (enemy.transform.position != house.transform.position)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, house.transform.position, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}

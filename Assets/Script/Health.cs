using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    [SerializeField]
    public float health = 100f;
    PolygonCollider2D houseCollider;


    void Start()
    {
        houseCollider = GetComponent<PolygonCollider2D>();
        healthBar = Image.FindObjectOfType<Image>();
    }
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Goober")
        {
            Debug.Log("Enemy hit");
            var timeSpan = DateTime.Now;
            health -= 10f;
            healthBar.fillAmount = health / 1000f;
        }
    }

}

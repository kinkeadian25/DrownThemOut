using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChangeColor : MonoBehaviour
{
    [SerializeField] public Color color1;
    [SerializeField] public Color color2;
    private Color originalColor;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public Color ChangeColor1()
    {
        return color1;
    }

    public Color ChangeColor2()
    {
        return color2;
    }

    public Color ResetColor()
    {
        return originalColor;
    }
}

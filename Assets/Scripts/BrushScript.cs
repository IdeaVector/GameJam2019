using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BrushScript : MonoBehaviour
{
    public Color color;
    private SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = color;
        Destroy(gameObject, 3);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(gameObject);
    }
}
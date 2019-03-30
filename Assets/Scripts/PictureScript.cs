﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureScript : MonoBehaviour
{
    public GameObject newSprite;
    private SpriteRenderer rend;
    public Color color;
    private bool isColorSetted = false;

    void Start()
    {
        List<Color> colorList = new List<Color>();
        colorList.Add(Color.red);
        colorList.Add(Color.white);
        colorList.Add(Color.green);
        colorList.Add(Color.blue);
        Color currentColor = colorList[Random.Range(0, colorList.Count)];
        SetColor(currentColor);
    }

    private void Update()
    {
    }

    public void DrawPicture()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sortingOrder = 0;
    }

    public void SetColor(Color newColor)
    {
        color = newColor;
        rend = GetComponent<SpriteRenderer>();
        rend.color = newColor;
        isColorSetted = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blat")
        {
            BrushScript script = collision.GetComponent<BrushScript>();
            if (script.color == color)
            {
                DrawPicture();
            }
        }
    }
}

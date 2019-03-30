using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureScript : MonoBehaviour
{
    public GameObject newSprite;
    private SpriteRenderer rend;
    public Color color;

    void Start()
    {
        SetColor(Color.red);
    }

    public void DrawPicture()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sortingOrder = 0;
    }

    public void SetColor(Color newColor)
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = newColor;
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

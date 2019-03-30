using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureScript : MonoBehaviour
{
    private SpriteRenderer rend;
    public Color color;

    void Start()
    {
        color = Color.red;
        Sprite sprite = GetComponent<Sprite>();
        //rend = sprite.GetComponent<SpriteRenderer>();
        rend.color = color;
    }
    
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAssign : MonoBehaviour
{
    public Color[] colors;
    void Start()
    {
        Color currentColor = colors[Random.Range(0, colors.Length)];
        GetComponent<PictureScript>().color = currentColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
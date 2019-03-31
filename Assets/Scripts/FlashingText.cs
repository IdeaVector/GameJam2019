using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour
{
    public float timer;
    private bool isReady = false;
    private int counter = 0;

    private void Start()
    {
        Color color = GetComponent<Text>().color;
        color.a = 0f;
        GetComponent<Text>().color = color;
    }

    void Update()
    {
        if (counter < 150)
        {
            counter++;
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= 0.5)
            {
                Color color = GetComponent<Text>().color;
                color.a = 0f;
                GetComponent<Text>().color = color;
            }
            if (timer >= 1)
            {
                Color color = GetComponent<Text>().color;
                color.a = 100f;
                GetComponent<Text>().color = color;
                timer = 0;
            }
        }       
    }
}

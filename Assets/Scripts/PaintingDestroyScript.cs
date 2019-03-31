using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingDestroyScript : MonoBehaviour
{
    public GameObject colorBox;
         
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (transform.position.x + 2 < player.transform.position.x)
            {
                PictureScript script = colorBox.GetComponent<PictureScript>();
                if(!script.isPainted)
                {
                    int score = PlayerPrefs.GetInt("Unpainted");
                    score++;
                    PlayerPrefs.SetInt("Unpainted", score);
                    Destroy(gameObject);
                }   
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "rainbowLine")
        {

        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingDestroyScript : MonoBehaviour
{
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (transform.position.x + 2 < player.transform.position.x)
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background2D : MonoBehaviour
{
    public GameObject obj;
    private Transform BG;
    public float speedBG = 0.005f;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        BG = obj.transform;
    }

    void Start()
    {
    }

    Vector3 GetVector(Vector3 position, float speed)
    {
        float posX = position.x;
        posX += cam.velocity.x * speed;
        return new Vector3(posX, position.y, position.z);
    }

    void Update()
    {
        if (BG) BG.position = GetVector(BG.position, speedBG);
    }
}

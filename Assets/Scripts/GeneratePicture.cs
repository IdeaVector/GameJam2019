using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePicture : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    private List<GameObject> objList;
    void Start()
    {
        objList = new List<GameObject>();
        objList.Add(obj1);
        objList.Add(obj2);
        objList.Add(obj3);
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        GameObject obj = objList[Random.Range(0, objList.Count)];
        rend.sprite = obj.GetComponent<SpriteRenderer>().sprite;
    }
}

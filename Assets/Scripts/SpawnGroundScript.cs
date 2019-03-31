using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGroundScript : MonoBehaviour
{

    [SerializeField]
    public GameObject[] groundObj;
    private GameObject tmpObject;
    public float spawnMinTime = 1f;
    public float spawnMaxTime = 2f;
    bool alreadySpawned = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        float playerpos = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        if (Mathf.Abs(transform.position.x - playerpos) < 10 && alreadySpawned == false)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject cr_gobj = groundObj[Random.Range(0, groundObj.GetLength(0))];
        float posX = transform.position.x + GetComponent<BoxCollider2D>().bounds.size.x / 2 + Random.Range(0.0f, 6.0f) + cr_gobj.GetComponent<BoxCollider2D>().bounds.size.x / 2;
        float posY = transform.position.y + Random.Range(-6.0f, 6.0f);
        Vector2 spawnPosition = new Vector2(posX, posY);
        tmpObject = Instantiate(cr_gobj, spawnPosition, Quaternion.identity);
        alreadySpawned = true;
        //Invoke("Spawn", Random.Range(spawnMinTime, spawnMaxTime));
    }
}

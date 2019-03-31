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

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + Random.Range(-2.0f, 2.0f));
        tmpObject = Instantiate(groundObj[Random.Range(0, groundObj.GetLength(0))], spawnPosition, Quaternion.identity);

        Invoke("Spawn", Random.Range(spawnMinTime, spawnMaxTime));
    }
}

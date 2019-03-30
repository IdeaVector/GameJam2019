using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGroundScript : MonoBehaviour
{

    [SerializeField]
    public GameObject[] groundObj;
    public float spawnMinTime = 1f;
    public float spawnMaxTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Instantiate(groundObj[Random.Range(0, groundObj.GetLength(0))], transform.position, Quaternion.identity);
        invoke("Spawn", Random.Range(spawnMinTime, spawnMaxTime));
    }
}

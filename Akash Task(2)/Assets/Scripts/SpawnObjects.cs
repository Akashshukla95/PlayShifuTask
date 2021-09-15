using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int timeforcollectables;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", 5, 6);

    }

    Vector2 GetSpawnPoint()
    {
        float x = Random.Range(-4f, 4f);
        //float y = Random.Range(0f, 0f, 0f);
        float y = Random.Range(-4f, 4f);
        //float z = Random.Range(-4f, 4f);

        return new Vector2(x, y);
        //return new Vector2(x, 0, z);
    }

    void SpawnObj()
    {
        Instantiate(objectToSpawn, GetSpawnPoint(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public GameObject[] crates;
    private float xRange = 10;
    private float spawnRate = 2;
    private float startDelay = 5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCrate", startDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCrate()
    {
        Vector3 position = new Vector3(Random.Range(-xRange, xRange), 14, -0.5f);
        GameObject crate = crates[Random.Range(0, crates.Length)];
        Instantiate(crate, position, crate.transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject cratePrefab;
    public float spawnInterval = 2f;
    public int CrateValue;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCrate", 1f, spawnInterval);
    }


    void SpawnCrate()
    {
        CrateValue = Random.Range(1, 10); // Random crate value between 1 and 10
        float randomX = Random.Range(-8f, 8f); 
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0);
        GameObject newCrate = Instantiate(cratePrefab, spawnPosition, Quaternion.identity);
        newCrate.GetComponent<Crate>().crateValue = CrateValue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject cratePrefab;
    public float spawnInterval = 2f;
    public int CrateValue;

    [Header("Dynamic")]
    public float BoundsX;
    public float BoundsY;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCrate", 1f, spawnInterval);
    }


    void SpawnCrate()
    {
        CrateValue = Random.Range(1, 10); // Random crate value between 1 and 10
        float randomX = Random.Range(-BoundsX, BoundsX); 
        Vector3 spawnPosition = new Vector3(randomX, BoundsY, 0);
        GameObject newCrate = Instantiate(cratePrefab, spawnPosition, Quaternion.identity);
        newCrate.GetComponent<Crate>().crateValue = CrateValue;
    }
}

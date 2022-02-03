using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectsPrefabs;
    private float spawnRangeZ = 7;
    private float spawnRangeX = 12;
    private float startDelay = 4;
    private float spawnInterval = 4;
    public PlayerController player;
    Vector3 spawnPos = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.collide == true)
            player.transform.position = player.transform.position;
        else{
            player.transform.position = Vector3.MoveTowards(player.transform.position, spawnPos, Time.deltaTime * 7);
        }
    }

    void SpawnObject(){
            player.collide = false;
            spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),0,Random.Range(-spawnRangeZ,spawnRangeZ));
            int objectIndex = Random.Range(0, objectsPrefabs.Length);    
            Instantiate(objectsPrefabs[objectIndex], spawnPos, objectsPrefabs[objectIndex].transform.rotation);
    }
}

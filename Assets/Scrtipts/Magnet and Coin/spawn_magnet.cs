using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_magnet : MonoBehaviour
{
    public GameObject[] magnet;
    public Transform[] spawnPoint;

    private int rand;
    private int randPosition;
    public float startTimeBtwSpawns;
    private float timeBtwSpawns;
    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, magnet.Length);
            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(magnet[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;






        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaterSpawner : MonoBehaviour {

    public GameObject waterSpawner;

    public Transform[] spawnPoints;

    public Vector2 timerMinMax;

    float timer;



	// Use this for initialization
	void Start () {
        timer = Random.Range(timerMinMax.x, timerMinMax.y);
    }
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Spawn();
            timer = Random.Range(timerMinMax.x, timerMinMax.y);
        }

	}

    void Spawn()
    {
        Instantiate(waterSpawner, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
    }

}

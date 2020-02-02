using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaterSpawner : MonoBehaviour {

    public GameObject waterSpawner;

    public Transform[] spawnPoints;

    public Vector2 timerMinMax;

    float timer;

    public Camera playerCamera;

    public Vector3 cameraStartPos;
    public float screenShakeDuration;
    bool screenShake;

	// Use this for initialization
	void Start () {
        timer = Random.Range(timerMinMax.x, timerMinMax.y);
        cameraStartPos = playerCamera.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Spawn();
            timer = Random.Range(timerMinMax.x, timerMinMax.y);
        }
        if (screenShake)
        {
            ScreenShake();
        }
	}

    void Spawn()
    {
        Instantiate(waterSpawner, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        if (!screenShake)
        {
            StartCoroutine(StartScreenShake());
        }
    }

    void ScreenShake()
    {
        playerCamera.transform.position = new Vector3(cameraStartPos.x - Random.Range(-.1f, .1f), cameraStartPos.y - Random.Range(-.1f, .1f), cameraStartPos.z);
    }

    IEnumerator StartScreenShake()
    {
        screenShake = true;
        yield return new WaitForSeconds(screenShakeDuration);
        screenShake = false;
    }

}

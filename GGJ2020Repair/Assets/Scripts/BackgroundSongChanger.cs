using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSongChanger : MonoBehaviour {

    public AudioSource audioSource1, audioSource2;
    public float waterThreshold;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Spawner.amountOfWaterParticles >= waterThreshold)
        {
            audioSource1.volume = 0;
            audioSource2.volume = 1;
        } else {
            audioSource1.volume = 1;
            audioSource2.volume = 0;
        }
	}
}

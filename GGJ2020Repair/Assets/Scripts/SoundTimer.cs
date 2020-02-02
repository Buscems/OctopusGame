using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTimer : MonoBehaviour {
    
    private AudioSource audioSource;
    public static float timer;
    public float minTimer, maxTimer;
    public AudioClip[] wetSounds;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        timer = Random.Range(minTimer, maxTimer);
	}
	
	// Update is called once per frame
	void Update () {
        //timer -= Time.deltaTime;

        if(timer <= 0){
            audioSource.clip = wetSounds[Random.Range(0, wetSounds.Length)];
            audioSource.Play();
            timer = Random.Range(minTimer, maxTimer);
        }
	}
}

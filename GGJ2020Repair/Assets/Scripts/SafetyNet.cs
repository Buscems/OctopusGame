using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyNet : MonoBehaviour {

    public GameObject leftEye, rightEye, leftSpawn, rightSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Spawner.amountOfWaterParticles);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            Spawner.amountOfWaterParticles--;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "LeftEye")
        {
            leftEye.transform.position = leftSpawn.transform.position;
        }

        if (other.gameObject.tag == "RightEye")
        {
            rightEye.transform.position = rightSpawn.transform.position;
        }

    }

}

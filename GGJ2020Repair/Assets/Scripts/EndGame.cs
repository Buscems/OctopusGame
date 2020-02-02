using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public GameObject number;
    bool startEnd;

    public Sprite[] numbers;

	// Use this for initialization
	void Start () {
        number.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Spawner.amountOfWaterParticles >= 400 && !startEnd)
        {
            StartCoroutine(StartEnd());
        }
        if(Spawner.amountOfWaterParticles < 400)
        {
            StopCoroutine(StartEnd());
            startEnd = false;
            number.SetActive(false);
        }

	}

    IEnumerator StartEnd()
    {
        startEnd = true;
        for (int i = 0; i < numbers.Length; i++)
        {
            number.SetActive(false);
            number.SetActive(true);
            number.GetComponent<Image>().sprite = numbers[i];
            yield return new WaitForSeconds(1);
        }

    }

}

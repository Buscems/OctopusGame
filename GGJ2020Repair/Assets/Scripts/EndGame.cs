using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public GameObject number;
    bool startEnd;

    public Sprite[] numbers;

    public static float seconds;

	// Use this for initialization
	void Start () {

        seconds = 0;
        Spawner.amountOfWaterParticles = 0;
        TentacleMovement.holesPlugged = 0;
        PickTentacle.waterSucked = 0;

        number.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        seconds += Time.deltaTime;

        if (Spawner.amountOfWaterParticles >= 550 && !startEnd)
        {
            StartCoroutine(StartEnd());
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideCursor : MonoBehaviour {

	public GameObject fadeMenuToGame;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
		fadeMenuToGame.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
			fadeMenuToGame.SetActive(true);
		}
	}

    public void GoToGame()
    {
		SceneManager.LoadScene("LiquidScene");
    }
}

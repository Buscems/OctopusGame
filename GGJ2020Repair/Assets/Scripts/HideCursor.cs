using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideCursor : MonoBehaviour {

	public GameObject fadeMenuToGame, textHolder;
	public bool isTitleVisible;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
		fadeMenuToGame.SetActive(false);
		isTitleVisible = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKey && isTitleVisible == true)
        {
			fadeMenuToGame.SetActive(true);
		}
	}

    public void GoToGame()
    {
		SceneManager.LoadScene("LiquidScene");
    }

	public void TitleVisible()
	{
		isTitleVisible = true;
		textHolder.SetActive(true);
    }
}

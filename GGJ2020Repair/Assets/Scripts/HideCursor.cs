using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideCursor : MonoBehaviour {

<<<<<<< HEAD
	public GameObject fadeMenuToGame, textHolder;
	public bool isTitleVisible;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
		fadeMenuToGame.SetActive(false);
		textHolder.SetActive(false);
=======
	public GameObject fadeMenuToGame;
	public bool isTitleVisible;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
		fadeMenuToGame.SetActive(false);
>>>>>>> c52ffc5d1917da94ad7e9f0fd8861e158cbe7ccb
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
<<<<<<< HEAD
    }

	public void TitleVisible()
	{
		isTitleVisible = true;
		textHolder.SetActive(true);
=======
    }

	public void TitleVisible()
	{
		isTitleVisible = true;
>>>>>>> c52ffc5d1917da94ad7e9f0fd8861e158cbe7ccb
	}
}

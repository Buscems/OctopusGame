using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideCursor : MonoBehaviour {

	public GameObject fadeMenuToGame, textHolder;
	public bool isTitleVisible;

    public bool returnToTitle;

    public float returnTime;

    public GameObject fadeToMenu;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
		fadeMenuToGame.SetActive(false);
        textHolder.SetActive(false);
        isTitleVisible = false;
        fadeToMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKey && isTitleVisible == true)
        {
			fadeMenuToGame.SetActive(true);
		}
        if (returnToTitle)
        {
            StartCoroutine(GoToTitle());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

	}

    public void GoToGame()
    {
		SceneManager.LoadScene("LiquidScene");
    }

    public void GoToMENU()
    {
        SceneManager.LoadScene("Title");
    }

    public void GoToEnd()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void TitleVisible()
	{
		isTitleVisible = true;
		textHolder.SetActive(true);
    }

    IEnumerator GoToTitle()
    {
        returnToTitle = false;
        yield return new WaitForSeconds(returnTime);
        fadeToMenu.SetActive(true);
    }

}

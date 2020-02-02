using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndScene : MonoBehaviour {

    public Text timeLasted;
    public Text holesPlugged;
    public Text waterSucced;

	// Use this for initialization
	void Start () {
        int hours = Mathf.FloorToInt(EndGame.seconds / 3600f);
        int minutes = Mathf.FloorToInt((EndGame.seconds % 3600) / 60);
        int seconds = Mathf.FloorToInt(EndGame.seconds % 60);

        string formattedText = "";
        if (hours > 0)
        {
            formattedText = string.Format("TIME LASTED: {0:0} hours, {1:0} minutes, {2:0} seconds", hours, minutes, seconds);
        }
        else if(minutes > 0)
        {
            formattedText = string.Format("TIME LASTED: {0:0} minutes, {1:0} seconds", minutes, seconds);
        }
        else
        {
            formattedText = string.Format("TIME LASTED: {0:0} seconds", seconds);
        }
        timeLasted.text = formattedText;

        holesPlugged.text = "HOLES PLUGGED: " + TentacleMovement.holesPlugged;

        waterSucced.text = "WATER SUCKED: " + PickTentacle.waterSucked;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

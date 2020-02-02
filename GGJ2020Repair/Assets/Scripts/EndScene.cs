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

        timeLasted.text = string.Format("Time Lasted: {0:00} : {1:00} : {2:00}", hours, minutes, seconds);

        holesPlugged.text = "Holes Plugged " + TentacleMovement.holesPlugged;

        waterSucced.text = "Water Sucked " + PickTentacle.waterSucked;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

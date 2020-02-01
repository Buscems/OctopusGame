using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Rewired.ControllerExtensions;

public class PickTentacle : MonoBehaviour {

    //the following is in order to use rewired
    [Tooltip("Reference for using rewired")]
    [HideInInspector]
    public Player myPlayer;
    [Header("Rewired")]
    [Tooltip("Number identifier for each player, must be above 0")]
    public int playerNum;

    public GameObject[] tentacle;
    public int currentTentacle;

    public Color playerColor;

    private void Awake()
    {
        //Rewired Code
        myPlayer = ReInput.players.GetPlayer(playerNum - 1);
        ReInput.ControllerConnectedEvent += OnControllerConnected;
        CheckController(myPlayer);
    }

    // Use this for initialization
    void Start () {

        switch (playerNum)
        {
            case 1:
                playerColor = Color.red;
                break;
            case 2:
                playerColor = Color.blue;
                break;
            case 3:
                playerColor = Color.cyan;
                break;
            case 4:
                playerColor = Color.yellow;
                break;
        }

        for (int i = 0; i < tentacle.Length; i++)
        {
            tentacle[i].GetComponent<TentacleMovement>().enabled = false;
            tentacle[i].GetComponent<SpriteRenderer>().color = Color.white;
        }
        tentacle[currentTentacle].GetComponent<TentacleMovement>().enabled = true;
        tentacle[currentTentacle].GetComponent<SpriteRenderer>().color = playerColor;

    }
	
	// Update is called once per frame
	void Update () {

        
        if (myPlayer.GetButtonDown("SwitchTentacle"))
        {
            if (currentTentacle < tentacle.Length - 1)
            {
                currentTentacle++;
            }
            else
            {
                currentTentacle = 0;
            }
            for (int i = 0; i < tentacle.Length; i++)
            {
                tentacle[i].GetComponent<TentacleMovement>().enabled = false;
                tentacle[i].GetComponent<SpriteRenderer>().color = Color.white;
                tentacle[i].GetComponent<TentacleMovement>().actives[playerNum] = false;
            }
            tentacle[currentTentacle].GetComponent<TentacleMovement>().enabled = true;
            tentacle[currentTentacle].GetComponent<SpriteRenderer>().color = playerColor;
            tentacle[currentTentacle].GetComponent<TentacleMovement>().active = true;
        }

	}

    //[REWIRED METHODS]
    //these two methods are for ReWired, if any of you guys have any questions about it I can answer them, but you don't need to worry about this for working on the game - Buscemi
    void OnControllerConnected(ControllerStatusChangedEventArgs arg)
    {
        CheckController(myPlayer);
    }

    void CheckController(Player player)
    {
        foreach (Joystick joyStick in player.controllers.Joysticks)
        {
            var ds4 = joyStick.GetExtension<DualShock4Extension>();
            if (ds4 == null) continue;//skip this if not DualShock4
            switch (playerNum)
            {
                case 4:
                    ds4.SetLightColor(Color.yellow);
                    break;
                case 3:
                    ds4.SetLightColor(Color.green);
                    break;
                case 2:
                    ds4.SetLightColor(Color.blue);
                    break;
                case 1:
                    ds4.SetLightColor(Color.red);
                    break;
                default:
                    ds4.SetLightColor(Color.white);
                    Debug.LogError("Player Num is 0, please change to a number > 0");
                    break;
            }
        }
    }


}

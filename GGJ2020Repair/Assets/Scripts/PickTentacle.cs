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

    [HideInInspector]
    public Color playerColor;

    public Color player1, player2, player3, player4, player5, player6, player7, player8;

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
                playerColor = player1;
                break;
            case 2:
                playerColor = player2;
                break;
            case 3:
                playerColor = player3;
                break;
            case 4:
                playerColor = player4;
                break;
            case 5:
                playerColor = player5;
                break;
            case 6:
                playerColor = player6;
                break;
            case 7:
                playerColor = player7;
                break;
            case 8:
                playerColor = player8;
                break;
        }
        /*
        for (int i = 0; i < tentacle.Length; i++)
        {
            for (int k = 0; k < tentacle[currentTentacle].GetComponent<TentacleMovement>().actives.Length; k++)
            {
                if (tentacle[i].GetComponent<TentacleMovement>().actives[k] && k != playerNum - 1)
                {

                }
                else
                {
                    tentacle[i].GetComponent<TentacleMovement>().enabled = false;
                    tentacle[i].GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
        */
        tentacle[currentTentacle].GetComponent<TentacleMovement>().enabled = true;
        tentacle[currentTentacle].GetComponent<SpriteRenderer>().color = playerColor;
        tentacle[currentTentacle].GetComponent<TentacleMovement>().playerNum = playerNum;
    }
	
	// Update is called once per frame
	void Update () {

        /*
        if (myPlayer.GetButtonDown("SwitchTentacle"))
        {
            StartCoroutine(SwitchTentacle());
        }
        */

        /*
        if(tentacle[currentTentacle].GetComponent<TentacleMovement>().actives[playerNum - 1])
        {
            tentacle[currentTentacle].GetComponent<TentacleMovement>().enabled = true;
        }
        */
        if (myPlayer.GetButtonDown("Suck"))
        {
            Collider2D[] waterStuff =  Physics2D.OverlapCircleAll(transform.position, 1.5f);
            foreach(Collider2D water in waterStuff)
            {
                if(water.tag == "Water")
                {
                    Destroy(water.gameObject);
                }
            }
        }

    }

    
    IEnumerator SwitchTentacle()
    {
        currentTentacle++;

        if (currentTentacle >= tentacle.Length)
        {
            currentTentacle = 0;
        }

        for (int i = 0; i < tentacle[currentTentacle].GetComponent<TentacleMovement>().actives.Length; i++)
        {
            if(tentacle[currentTentacle].GetComponent<TentacleMovement>().actives[i] && i != playerNum--)
            {
                currentTentacle++;
                yield return null;
            }
        }

        for (int i = 0; i < tentacle.Length; i++)
        {
            for (int k = 0; k < tentacle[i].GetComponent<TentacleMovement>().actives.Length; k++)
            {
                if (!tentacle[i].GetComponent<TentacleMovement>().actives[k])
                {
                    tentacle[i].GetComponent<TentacleMovement>().enabled = false;
                    tentacle[i].GetComponent<SpriteRenderer>().color = Color.white;
                    tentacle[i].GetComponent<TentacleMovement>().actives[playerNum - 1] = false;
                }
            }
        }
        tentacle[currentTentacle].GetComponent<TentacleMovement>().playerNum = this.playerNum;
        tentacle[currentTentacle].GetComponent<TentacleMovement>().enabled = true;
        tentacle[currentTentacle].GetComponent<SpriteRenderer>().color = playerColor;
        tentacle[currentTentacle].GetComponent<TentacleMovement>().actives[playerNum - 1] = true;
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

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Rewired.ControllerExtensions;

public class TentacleMovement : MonoBehaviour {

    //the following is in order to use rewired

    [Tooltip("Reference for using rewired")]
    [HideInInspector]
    public Player myPlayer;
    [Header("Rewired")]
    [Tooltip("Number identifier for each player, must be above 0")]
    public int playerNum;

    Rigidbody2D rb;

    public Vector2 velocity;

    public float speed;

    public bool[] actives;

    GameObject collidingObject;

    private AudioSource plugSource;
    public AudioClip[] plugSounds;

    public static int holesPlugged;

    private void Awake()
    {
        //Rewired Code
        myPlayer = ReInput.players.GetPlayer(playerNum - 1);
        ReInput.ControllerConnectedEvent += OnControllerConnected;
        CheckController(myPlayer);
    }

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        plugSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

        velocity = new Vector2(myPlayer.GetAxisRaw("MoveHorizontal"), myPlayer.GetAxisRaw("MoveVertical"));

        if(velocity.x != 0 || velocity.y != 0){
            SoundTimer.timer -= Time.deltaTime;
        }

        if(collidingObject != null && myPlayer.GetButtonDown("Plug"))
        {
            plugSource.clip = plugSounds[Random.Range(0, plugSounds.Length)];
            plugSource.Play();
            Destroy(collidingObject);
            collidingObject = null;
            holesPlugged++;
        }

        rb.MovePosition(rb.position + velocity * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hole")
        {
            collidingObject = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hole")
        {
            collidingObject = null;
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

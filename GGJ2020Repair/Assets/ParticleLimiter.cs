using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLimiter : MonoBehaviour {

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (rb.velocity.x >= 20)
        {
            rb.velocity = new Vector2(8, rb.velocity.y);
        }
        if (rb.velocity.y >= 20)
        {
            rb.velocity = new Vector2(rb.velocity.x, 8);
        }

    }
}

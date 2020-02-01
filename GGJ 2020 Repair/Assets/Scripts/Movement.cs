using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public Vector2 input;
    public bool p1, p2;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (p1)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            rb.MovePosition(rb.position + input * speed * Time.deltaTime);
        }
        if(p2){
            input.x = Input.GetAxisRaw("Horizontal2");
            input.y = Input.GetAxisRaw("Vertical2");
            rb.MovePosition(rb.position + input * speed * Time.deltaTime);
        }
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    // controls and speed
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        // setting up Rigidbody2D
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        var vel = rb2d.velocity;
		// check what buttom is being pressed
        if (Input.GetKey(moveUp)) {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown)) {
            vel.y = -speed;
        }
        else {
            vel.y = 0;
        }

        rb2d.velocity = vel;

        // checks if at the edge
        var pos = transform.position;
        if (pos.y > boundY) {
            pos.y = boundY;
        }
        else if (pos.y < -boundY) {
            pos.y = -boundY;
        }

        // udates position
        transform.position = pos;
    }
}

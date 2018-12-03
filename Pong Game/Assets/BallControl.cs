using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    private Rigidbody2D rb2d;


    // chooses a random direction (left or right)
    // then makes the ball move
    void GoBall()
    {

        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }


    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();

        //waits 2 seconds before executing GoBall 
        Invoke("GoBall", 2);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // stops ball and resets its position
    // call when a win condition is met
    void ResetBall() {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }


    // retarts the game 
    // call when restart button is pressed
    void RestartGame() {
        ResetBall();
        // waits one second before starting game
        Invoke("GoBall", 1);
    }


    // when a collision with a paddle occurs
    // adjusts velocity appropriately using both speed
    // of ball and of paddle
    private void OnCollisionEnter2D(Collision2D coll) {
        if(coll.collider.CompareTag("Player")) {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

}

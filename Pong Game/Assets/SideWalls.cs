using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {



    // once something collides with the wall
    // updates the score or restarts the game
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.name == "Ball") {
            string wallName = transform.name;
            GameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }

}

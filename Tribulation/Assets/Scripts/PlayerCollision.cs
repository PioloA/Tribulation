using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
   [Header("Script and Game Reference")]
    public PlayerController controller;  //reference to PlayerController script

    //function that runs when we hit on an object with collision
    void OnCollisionEnter2D (Collision2D collision)
    {
        //if player hits objects that are tagged with Obstacle
        if (collision.collider.tag == "Obstacle")
        {
            controller.enabled = false; //disables movement
        }

        //if player hits with an onject tagged as Enemy
        if (collision.collider.tag == "Enemy")
        {
            controller.enabled = false; // disables movement
        }
    }
}

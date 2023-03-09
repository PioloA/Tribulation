using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    //function when colliding with ammo pick-ups
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponentInChildren<PlayerController>(); // checks the player if it has the component
        if(player)
        {
            player.AddAmmo(player.maxClipSize); // calls the function Addammo and adds ammo upon collision
            Destroy(gameObject);
        }
    }
}

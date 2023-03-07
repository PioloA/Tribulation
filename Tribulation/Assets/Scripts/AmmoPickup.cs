using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if(collision.gameObject.tag == "Player")
        {
            player.AddAmmo(player.maxAmmoSize);
            Destroy(gameObject);
        }
    }
}

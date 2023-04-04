using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Bullet")]
    public float Speed = 20f;
    private float destroyTime = 1f;

    //destroy object in 2 seconds if bullet did not collide
    void Start ()
    {
        Destroy (gameObject, destroyTime);
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    //destory object on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

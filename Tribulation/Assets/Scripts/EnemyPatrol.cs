using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 1;
    public bool moveRight;

    void Update()
    {
        if(moveRight)
        {
            transform.Translate(1 * Time.deltaTime * speed, 0 ,0);
            transform.localScale = new Vector2 (1,1);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2 (-1,1);
        }
        
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Turn"))
        {
            if(moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }
}

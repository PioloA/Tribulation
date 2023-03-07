using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]private float playerSpeed = 5f;
    [SerializeField]private float jumpForce = 11f;

    [Header("Components")]
    [SerializeField]private Rigidbody2D player;
    public LayerMask groundLayer;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLength = 1.25f;

    [Header("Projectile")]
    public Projectile ProjectilePrefab;
    public Transform LaunchOffset;
    public int currentClip;
    public int maxClipSize = 5;
    public int currentAmmo;
    public int maxAmmoSize = 10;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // detection if player is on the ground
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);

        // makes the player run on the right continously 
        transform.Translate(Vector2.right*(Time.deltaTime * playerSpeed));

        // makes the player jump
        if (Input.GetButtonDown("Jump") && onGround)
        {
             player.velocity = new Vector2(player.velocity.x, jumpForce);
        }

        //makes the player shoots bullet
        if (Input.GetKeyDown(KeyCode.J))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

    }

    void Fire ()
    {
        if(currentClip > 0)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation); //calls the prefab and makes duplicates of the prefab when called
            currentClip --;
        }
    }

    void Reload ()
    {
        int reloadAmount = maxClipSize - currentClip; // how many bullets to refill current clip
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentClip -= reloadAmount;
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if(currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }

    
    // gizmos that shows the trigger if player is on the ground in the editor
    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundLength);
    }
    
}
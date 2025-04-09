using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WroughtDirection : MonoBehaviour
{
    private Transform player;
    private Enemy_Wrought WroughtController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        WroughtController = GetComponentInParent<Enemy_Wrought>();
    }

    void Update()
    {
        HandleLook();
    }

    void HandleLook()
    {
        if (player != null && !WroughtController.isAttacking)
        {
            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Set the rotation to face the player (only around the Z-axis)
            directionToPlayer.z = 0;  // Ignore any difference in Z-axis (2D plane)
            
            if (directionToPlayer != Vector3.zero)  // Avoid errors if enemy and player are at the same position
            {
                // Calculate the angle in radians and convert to degrees
                float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

                // Rotate the enemy to face the player
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }
}

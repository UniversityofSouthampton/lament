using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float healthAddition = 2f;

    void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerHealth.currentHealth < playerHealth.maxHealth)
        {
            Destroy(gameObject);
            if (playerHealth.currentHealth == 4f)
            {
                playerHealth.currentHealth = playerHealth.currentHealth + 1;
            }
            else
            {
                playerHealth.currentHealth = playerHealth.currentHealth + healthAddition;
            }
        }
    }
}

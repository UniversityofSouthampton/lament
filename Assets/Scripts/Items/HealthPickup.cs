using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float healthAddition = 2f;
    AudioManager audioManager;
    void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerHealth.currentHealth < playerHealth.maxHealth)
            {
                Destroy(gameObject);
                audioManager.PlaySfx(audioManager.heal);
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
}

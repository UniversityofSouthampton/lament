using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;

    public int healthAddition = 2;
    AudioManager audioManager;
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerStatsManager.Instance.currentHealth < PlayerStatsManager.Instance.maxHealth)
            {
                Destroy(gameObject);
                audioManager.PlaySfx(audioManager.heal);
                if (PlayerStatsManager.Instance.currentHealth == PlayerStatsManager.Instance.maxHealth - 1)
                {
                    PlayerStatsManager.Instance.currentHealth = PlayerStatsManager.Instance.currentHealth + 1;
                    
                }
                else
                {
                    PlayerStatsManager.Instance.currentHealth = PlayerStatsManager.Instance.currentHealth + healthAddition;
                }
            }
        }
    }
}

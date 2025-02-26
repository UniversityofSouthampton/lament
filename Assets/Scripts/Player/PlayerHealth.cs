using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerMovement playerController;

    [Header("Health Stats")]

    public float maxHealth = 5;
    public float currentHealth;

    public float dmgMultiplier = 1;

    public void Start()
    {
        currentHealth = maxHealth;
        playerController = GetComponent<PlayerMovement>();
    }

    
    
    
    public void TakeDamage(int damage)
    {
        if(!playerController.isDashing)
        {
            currentHealth -= damage;
            Debug.Log("Player health: " + currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
        else
        {
            return;
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Player has died!");
    }
    
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CompareTag("Damage"))
        {
            TakeDamage(1);
        }
    }


}

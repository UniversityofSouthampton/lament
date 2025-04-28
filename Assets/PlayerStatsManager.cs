using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{

    public static PlayerStatsManager Instance;

    [Header("Player Stats")]
    public int currentHealth = 3;
    public int maxHealth = 3;
    
    [Header("Player Inventory")]
    public int currentTerraShards;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("PlayerStatsManager created!");
        }
        else
        {
            Debug.Log("Destroying duplicate PlayerStatsManager");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (maxHealth > 5)
        {
            maxHealth -= 1;
        }
        else if (currentHealth > 5)
        {
            currentHealth -= 1;
        }
    }

    public void UpdateMaxHealth(int amount)
    {
        
        maxHealth += amount;
        currentHealth = maxHealth;
    }

    public void takeTerraShards(int pickupTerraShards)
    {
        currentTerraShards += pickupTerraShards;
        //Debug.Log("Current terra shards:" + currentTerraShards);
    }
}

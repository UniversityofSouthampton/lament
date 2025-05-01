using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int currentTerraShards;
    //public TerrashardCounter cm;

    void Start()
    {
        currentTerraShards = 10;
    }

    void Update()
    {
        currentTerraShards = PlayerStatsManager.Instance.currentTerraShards;
    }

    public void takeTerraShards(int pickupTerraShards)
    {
        currentTerraShards += pickupTerraShards + PlayerStatsManager.Instance.terraShardBoost;
        //Debug.Log("Current terra shards:" + currentTerraShards);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int currentTerraShards;

    // Start is called before the first frame update
    void Start()
    {
        currentTerraShards = 0;
    }

    // Update is called once per frame
    public void takeTerraShards(int pickupTerraShards)
    {
        currentTerraShards += pickupTerraShards;
        Debug.Log("Current terra shards:" + currentTerraShards);
    }
}

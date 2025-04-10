using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerrashardCounter : MonoBehaviour
{
    public TextMeshProUGUI TerrashardCount;
    public PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       TerrashardCount.text = playerInventory.currentTerraShards.ToString();
    }
}

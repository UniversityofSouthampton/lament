using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public string doorID; // Must match Door.targetDoorID

    void Start()
    {
        if (SceneDoorData.destinationDoorID == doorID)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                player.transform.position = transform.position;
        }
    }
}

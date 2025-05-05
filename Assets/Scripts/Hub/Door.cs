using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string targetScene;
    public string targetDoorID; // ID of spawn point in the next scene

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneDoorData.destinationDoorID = targetDoorID;
            SceneController.instance.LoadScene(targetScene);
        }
    }
}

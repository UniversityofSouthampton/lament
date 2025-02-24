using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class RoomCameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera roomCamera; // Assign this via the Inspector or dynamically

    public GameObject player;


    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //Debug.Log("roomCamera.Priority is" + roomCamera.Priority);
        //Debug.Log("playerCamera.Priority is"+ playerCamera.Priority);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is in room");
            roomCamera.Priority = 10;  // Set a higher priority to the room camera when player enters
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            roomCamera.Priority = 5;  // Lower the priority when player leaves
        }
    }
}
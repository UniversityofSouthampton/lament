using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

    [Header("SpawnPoint Variables")]
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;


    public GameObject closedRoom;

    [Header("RespawnPoint Variables")]

    public GameObject[] yesTnoLRooms;
    public GameObject[] yesTnoBRooms;
    public GameObject[] yesTnoRRooms;
    public GameObject[] yesLnoTRooms;
    public GameObject[] yesLnoBRooms;
    public GameObject[] yesLnoRRooms;
    public GameObject[] yesBnoTRooms;
    public GameObject[] yesBnoLRooms;
    public GameObject[] yesBnoRRooms;
    public GameObject[] yesRnoTRooms;
    public GameObject[] yesRnoLRooms;
    public GameObject[] yesRnoBRooms;
    public GameObject annihilator;
}
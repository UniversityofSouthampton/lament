using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

    [Header("SpawnPoint Variables")]
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject bottomRoom;
    public GameObject topRoom;
    public GameObject leftRoom;
    public GameObject rightRoom;

    public GameObject closedRoom;



    public float waitTime;
    public bool spawnedBoss;
    public GameObject boss;
    public List<GameObject> rooms;

    void Update()
    {
        if(waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count-1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    Debug.Log("Boss is spawned");
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
    [Header("RespawnPoint Variables - NOT IN USE")]

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
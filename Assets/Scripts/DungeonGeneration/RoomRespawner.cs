using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRespawner : MonoBehaviour
{
	public int closingDirection;
	// 1 --> DONT need bottom door
	// 2 --> DONT need top door
	// 3 --> DONT need left door
	// 4 --> DONT need right door


	private RoomTemplates templates;
	private int rand;
	public bool spawned = false;

    public float waitTime = 4f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	void OnTriggerEnter2D(Collider2D other)
    {
		if(other.CompareTag("RespawnPoint"))
		{
			if(other.GetComponent<RoomRespawner>().spawned == false && spawned == false)
			{
			Instantiate(templates.annihilator, transform.position, Quaternion.identity);
			Destroy(gameObject);
			}
		}
        else if(other.CompareTag("Annihilator"))
		{
			Destroy(gameObject);
		}
        if(other.CompareTag("SpawnPoint"))
        {
            
            //With BOTTOM Doors
            
            if(other.GetComponent<RoomSpawner>().openingDirection == 1 && closingDirection == 2)
            {
                // Need to spawn a room WITH a BOTTOM door WITHOUT a TOP door
                rand = Random.Range(0, templates.yesBnoTRooms.Length);
				Instantiate(templates.yesBnoTRooms[rand], transform.position, templates.yesBnoTRooms[rand].transform.rotation);
            }
            else if(other.GetComponent<RoomSpawner>().openingDirection == 1 && closingDirection == 3) 
            {
                // Need to spawn a room WITH a BOTTOM door WITHOUT a LEFT door
                rand = Random.Range(0, templates.yesBnoLRooms.Length);
				Instantiate(templates.yesBnoLRooms[rand], transform.position, templates.yesBnoLRooms[rand].transform.rotation);
            }
            else if(other.GetComponent<RoomSpawner>().openingDirection == 1 && closingDirection == 4)
            {
                // Need to spawn a room WITH a BOTTOM door and WITHOUT a RIGHT door
                rand = Random.Range(0, templates.yesBnoRRooms.Length);
				Instantiate(templates.yesBnoRRooms[rand], transform.position, templates.yesBnoRRooms[rand].transform.rotation);
            }
            
            //With TOP Doors
        
            else if(other.GetComponent<RoomSpawner>().openingDirection == 2 && closingDirection == 1)
            {
                // Need to spawn a room WITH a TOP door WITHOUT a BOTTOM door
                rand = Random.Range(0, templates.yesTnoBRooms.Length);
				Instantiate(templates.yesTnoBRooms[rand], transform.position, templates.yesTnoBRooms[rand].transform.rotation);
            }
            else if(other.GetComponent<RoomSpawner>().openingDirection == 2 && closingDirection == 3)
            {
                // Need to spawn a room WITH a TOP door WITHOUT a LEFT door
                rand = Random.Range(0, templates.yesTnoLRooms.Length);
				Instantiate(templates.yesTnoLRooms[rand], transform.position, templates.yesTnoLRooms[rand].transform.rotation);
            }
            else if(other.GetComponent<RoomSpawner>().openingDirection == 2 && closingDirection == 4)
            {
                // Need to spawn a room WITH a TOP door WITHOUT a RIGHT door
                rand = Random.Range(0, templates.yesTnoRRooms.Length);
				Instantiate(templates.yesTnoRRooms[rand], transform.position, templates.yesTnoRRooms[rand].transform.rotation);
            }

            //With LEFT Doors

            else if(other.GetComponent<RoomSpawner>().openingDirection == 3 && closingDirection == 1)
            {
                // Need to spawn a room WITH a LEFT door WITHOUT a BOTTOM door
                rand = Random.Range(0, templates.yesLnoBRooms.Length);
				Instantiate(templates.yesLnoBRooms[rand], transform.position, templates.yesLnoBRooms[rand].transform.rotation);
            }
            else if(other.GetComponent<RoomSpawner>().openingDirection == 3 && closingDirection == 2)
            {
                // Need to spawn a room WITH a LEFT door WITHOUT a TOP door
                rand = Random.Range(0, templates.yesLnoTRooms.Length);
				Instantiate(templates.yesLnoTRooms[rand], transform.position, templates.yesLnoTRooms[rand].transform.rotation);
            }
            else if(other.GetComponent<RoomSpawner>().openingDirection == 3 && closingDirection == 4)
            {
                // Need to spawn a room WITH a LEFT door WITHOUT a RIGHT door
                rand = Random.Range(0, templates.yesLnoRRooms.Length);
				Instantiate(templates.yesLnoRRooms[rand], transform.position, templates.yesLnoRRooms[rand].transform.rotation);
            }

            //With Right Doors

            else if(other.GetComponent<RoomSpawner>().openingDirection == 4 && closingDirection == 1)
            {
                // Need to spawn a room WITH a RIGHT door Without a BOTTOM door
                rand = Random.Range(0, templates.yesRnoBRooms.Length);
				Instantiate(templates.yesRnoBRooms[rand], transform.position, templates.yesRnoBRooms[rand].transform.rotation);
            }
            else if(other.GetComponent<RoomSpawner>().openingDirection == 4 && closingDirection == 2)
            {
                // Need to spawn a room WITH a RIGHT door WITHOUT a TOP door
                rand = Random.Range(0, templates.yesRnoTRooms.Length);
				Instantiate(templates.yesRnoTRooms[rand], transform.position, templates.yesRnoTRooms[rand].transform.rotation);
            }
            else if(other.GetComponent<RoomSpawner>().openingDirection == 4 && closingDirection == 3)
            {
                // Need to spawn a room WITH a RIGHT door WITHOUT a LEFT door
                rand = Random.Range(0, templates.yesRnoLRooms.Length);
				Instantiate(templates.yesRnoLRooms[rand], transform.position, templates.yesRnoLRooms[rand].transform.rotation);
            }

            spawned = true;
        }
    }
}

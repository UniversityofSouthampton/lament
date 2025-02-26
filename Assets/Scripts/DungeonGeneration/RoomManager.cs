using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    // List of GameObjects to activate
    public GameObject objectsToActivate;

    public List<GameObject> enemies;
    public GameObject[] doors;
    // This function is called when a collision happens
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateObjects();
            enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        }
    }

    // Activate all the GameObjects in the list
    void ActivateObjects()
    {
        objectsToActivate.SetActive(true);
    }

    public void EnemyKilled(GameObject enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }

        if(enemies.Count == 0)
        {
            DeactivateDoors();
        }
    }

    void DeactivateDoors()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
    }
}

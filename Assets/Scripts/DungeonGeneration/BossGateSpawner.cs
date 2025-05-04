using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGateSpawner : MonoBehaviour
{
    public List<GameObject> enemiesInRoom = new List<GameObject>();
    public GameObject bossGateway;
    private bool playerHasEnteredRoom = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(playerEnteredRoom());
        }
        if (other.CompareTag("Enemy") && !enemiesInRoom.Contains(other.gameObject))
        {
            enemiesInRoom.Add(other.gameObject);
        }
    }

    private IEnumerator playerEnteredRoom()
    {
        yield return new WaitForSeconds (2f);
        playerHasEnteredRoom = true;
    }

    private void Update()
    {
        // Remove any dead enemies
        enemiesInRoom.RemoveAll(enemy => enemy == null);

        if (enemiesInRoom.Count == 0 && playerHasEnteredRoom)
        {
            bossGateway?.SetActive(true);
        }
    }
}

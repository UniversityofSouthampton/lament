using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3Manager : MonoBehaviour
{
    public GameObject Door_3;
    public List<GameObject> healthPotions; // assign these manually in the Inspector
    private bool playerHasEnteredRoom = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(playerEnteredRoom());
        }
    }

    private IEnumerator playerEnteredRoom()
    {
        yield return new WaitForSeconds(2f);
        playerHasEnteredRoom = true;
    }

    private void Update()
    {
        // Remove any picked-up (destroyed) potions from the list
        healthPotions.RemoveAll(p => p == null);

        // If no potions remain and the player has entered, open the door
        if (healthPotions.Count == 0 && playerHasEnteredRoom)
        {
            Door_3.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraShards : MonoBehaviour
{
    public int pickupTerraShards;
    public bool canPickUp = false;
    private GameObject player;
    AudioManager audioManager;

    void Start()
    {
        pickupTerraShards = Random.Range(1, 5);
        player = GameObject.FindGameObjectWithTag("Player");
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        //StartCoroutine(PickUp());
    }

    private IEnumerator PickUp()
    {
        yield return new WaitForSeconds(1f);
        canPickUp = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInventory>().takeTerraShards(pickupTerraShards);
            Destroy(gameObject);
            audioManager.PlaySfx(audioManager.teraPickup);
        }
    }
}

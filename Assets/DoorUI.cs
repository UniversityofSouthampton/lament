using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUI : MonoBehaviour
{
    public GameObject DoorUI_Text;

    private float UIDuration = 2.5f;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(OpenDoorUI());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DoorUI_Text.SetActive(false);
        }
    }


    private IEnumerator OpenDoorUI()
    {
        yield return new WaitForSeconds(1.5f);
        DoorUI_Text.SetActive(true);
        yield return new WaitForSeconds(UIDuration);
        DoorUI_Text.SetActive(false);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillTreeZone : MonoBehaviour
{
    public GameObject skillsCanvas;
    private bool playerInside;
    private bool isOpen;
    private PlayerControllerNew playerMovement;
    private AttackNew playerAttack;


    void Update()
    {
        Debug.Log("isOpen: " + isOpen);

        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !skillsCanvas.activeSelf;
            skillsCanvas.SetActive(isOpen);

            {
                if (playerMovement != null)
                    playerMovement.enabled = !isOpen;
                if (playerAttack != null)
                    playerAttack.enabled = !isOpen;

                //Time.timeScale = isOpen? 1f : 0f;
            }
        }
        Cursor.visible = isOpen;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            playerMovement = other.GetComponent<PlayerControllerNew>();
            playerAttack = other.GetComponent<AttackNew>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }


}

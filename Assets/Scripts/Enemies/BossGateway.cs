using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossGateway : MonoBehaviour
{

    public GameObject hasKey;
    public GameObject hasNoKey;
    private float UIDuration = 2.5f;

    private bool playerInside = false;


    void Update()
    {

        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if(PlayerStatsManager.Instance.hasBossKey == true)
            {
                StartCoroutine(hasKeyUI());
            }

            if(PlayerStatsManager.Instance.hasBossKey == false)
            {
                StartCoroutine(hasNoKeyUI());
            }
        }
    }

    private IEnumerator hasKeyUI()
    {
        hasKey.SetActive(true);
        yield return new WaitForSeconds(UIDuration);
        hasKey.SetActive(false);
        yield return SceneManager.LoadSceneAsync("BossIntroCutscene");
    }

    private IEnumerator hasNoKeyUI()
    {
        hasNoKey.SetActive(true);
        yield return new WaitForSeconds(UIDuration);
        hasNoKey.SetActive(false);
        PlayerStatsManager.Instance.currentHealth = PlayerStatsManager.Instance.maxHealth;
        yield return SceneManager.LoadSceneAsync("Hub");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
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

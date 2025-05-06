using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRoomPopup : MonoBehaviour
{
    public GameObject player;
    public GameObject PopUp;

    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EnablePopup());
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        PopUp.SetActive(false);
    }

    private IEnumerator EnablePopup()
    {
        yield return new WaitForSeconds(0.25f);
        PopUp.SetActive(true);
        yield return new WaitForSeconds(6);
        PopUp.SetActive(false);

    }

}

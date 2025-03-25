using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFall : MonoBehaviour
{
    public Transform playerRespawn;
    public GameObject player;
    public int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            other.GetComponent<PlayerControllerNew>().Fall();
            player.GetComponent<AttackNew>().isAttacking = true;
            player.GetComponent<AttackNew>().enabled = false;
            //player.GetComponent<PlayerControllerNew>().enabled = false;
            StartCoroutine(Fall());

        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(1f);
        player.transform.position = playerRespawn.position;
        player.GetComponent<AttackNew>().enabled = true;
        player.GetComponent<PlayerControllerNew>().enabled = true;
        player.GetComponent<AttackNew>().isAttacking = false;
    }
}

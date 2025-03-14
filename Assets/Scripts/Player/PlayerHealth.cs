using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerControllerNew playerController;

    [Header("Health Stats")]

    public float maxHealth = 5;
    public float currentHealth;
    private bool isDead = false;

    public float dmgMultiplier = 1;
    public GameObject player;
    Animator anim;
    
    public void Start()
    {
        currentHealth = maxHealth;
        playerController = GetComponent<PlayerControllerNew>();
        anim = GetComponent<Animator>();

    }
    
    public void TakeDamage(int damage)
    {
        if(!playerController.isDashing)
        {
            currentHealth -= damage;
            //Debug.Log("Player health: " + currentHealth);
            anim.SetTrigger("isHurt");
            
            if (currentHealth <= 0)
            {
                anim.SetTrigger("isDead");
                StartCoroutine(DestroyPlayer());
                
            }
        }
        else
        {
            return;
        }
    }
    private IEnumerator DestroyPlayer()
    {
        isDead = true;
        yield return new WaitForSeconds(1f);
        Debug.Log("Player has been killed");
        Destroy(gameObject);
    }
    
    
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CompareTag("Damage"))
        {
            TakeDamage(1);
           
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackNew : MonoBehaviour

{
    private PlayerControllerNew playerControllerNew;
    public GameObject upMelee;
    public GameObject downMelee;
    public GameObject leftMelee;
    public GameObject rightMelee;
    
    public float atkDuration = 0.6f;
    float atkTimer = 0f;
    public bool isAttacking = false;
    private bool isAttackCanceled = false;
    
    Animator anim;

    AudioManager audioManager;
    void Start()
    {
        playerControllerNew = GetComponent<PlayerControllerNew>();
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isAttacking)
        {
            CancelAttack();
            return;
        }
        CheckMeleeTimer();

        if(Input.GetMouseButton(0) && !isAttacking)
        {
            //left click attack
            HandleAttack();
            //Debug.Log("player has used melee1");
        }
    }

    void CancelAttack()
    {
        isAttacking = false;
        isAttackCanceled = true;
        anim.SetBool("isAttacking", false);
        StopAllCoroutines();
        
        DeactivateHitbox(upMelee);
        DeactivateHitbox(downMelee);
        DeactivateHitbox(leftMelee);
        DeactivateHitbox(rightMelee);
    }
    

    void HandleAttack()
    {
        StartCoroutine(MeleeActive());
        isAttacking = true;
        anim.SetTrigger("isAttacking 0");
        audioManager.PlaySfx(audioManager.playerattack);
    }

    private IEnumerator MeleeActive()
    {
        if (playerControllerNew.isFacingUp)
        {
            yield return new WaitForSeconds(0.15f);
            upMelee.SetActive(true);

            yield return new WaitForSeconds(0.2f);
            isAttacking = false;
            upMelee.SetActive(false);
            
        }
        else if (playerControllerNew.isFacingDown)
        {
            yield return new WaitForSeconds(0.15f);
            downMelee.SetActive(true);

            yield return new WaitForSeconds(0.2f);
            isAttacking = false;
            downMelee.SetActive(false);
            
        }
        else if (playerControllerNew.isFacingLeft)
        {
            yield return new WaitForSeconds(0.15f);
            leftMelee.SetActive(true);

            yield return new WaitForSeconds(0.2f);
            isAttacking = false;
            leftMelee.SetActive(false);
            
        }
        else if (playerControllerNew.isFacingRight)
        {
            yield return new WaitForSeconds(0.15f);
            rightMelee.SetActive(true);

            yield return new WaitForSeconds(0.2f);
            isAttacking = false;
            rightMelee.SetActive(false);
            
        }
    }
   
    private void ActivateHitbox(GameObject hitbox)
    {
        if (isAttackCanceled)
        {
            hitbox.SetActive(false); 
        }
        else
        {
            hitbox.SetActive(true); 
        }
    }

    //this code is for cancelling the hitbox when dashing
    private void DeactivateHitbox(GameObject hitbox)
    {
        if (isAttackCanceled)
        {
            hitbox.SetActive(false); 
        }
        else
        {
            hitbox.SetActive(false); 
        }
    }
    

    void CheckMeleeTimer()
    {
        if(isAttacking)
        {
            atkTimer += Time.deltaTime;
            if(atkTimer >= atkDuration)
            {
                atkTimer = 0;
                anim.SetBool("isAttacking", false);
            }
            
        }
    }
}

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

    void Start()
    {
        playerControllerNew = GetComponent<PlayerControllerNew>();
        anim = GetComponent<Animator>();
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
            Debug.Log("player has used melee1");
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
        anim.SetBool("isAttacking", true);
        StartCoroutine(MeleeActive());
        isAttacking = true;
    }

    private IEnumerator MeleeActive()
    {
        if (playerControllerNew.isFacingUp)
        {
            yield return new WaitForSeconds(0.3f);
            upMelee.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            isAttacking = false;
            upMelee.SetActive(false);
            
        }
        else if (playerControllerNew.isFacingDown)
        {
            yield return new WaitForSeconds(0.3f);
            downMelee.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            isAttacking = false;
            downMelee.SetActive(false);
            
        }
        else if (playerControllerNew.isFacingLeft)
        {
            yield return new WaitForSeconds(0.3f);
            leftMelee.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            isAttacking = false;
            leftMelee.SetActive(false);
            
        }
        else if (playerControllerNew.isFacingRight)
        {
            yield return new WaitForSeconds(0.3f);
            rightMelee.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            isAttacking = false;
            rightMelee.SetActive(false);
            
        }
    }
    private void ActivateHitbox(GameObject hitbox)
    {
        if (isAttackCanceled)
        {
            hitbox.SetActive(false); // Deactivate hitbox immediately if attack is canceled
        }
        else
        {
            hitbox.SetActive(true); // Activate hitbox
        }
    }

    // Method to deactivate hitbox and check for cancellation
    private void DeactivateHitbox(GameObject hitbox)
    {
        if (isAttackCanceled)
        {
            hitbox.SetActive(false); // Ensure the hitbox is deactivated
        }
        else
        {
            hitbox.SetActive(false); // Deactivate hitbox after attack
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

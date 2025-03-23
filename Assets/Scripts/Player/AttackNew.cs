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
    Animator anim;

    void Start()
    {
        playerControllerNew = GetComponent<PlayerControllerNew>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        CheckMeleeTimer();

        if(Input.GetMouseButton(0) && !isAttacking)
        {
            //left click attack
            HandleAttack();
        }
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

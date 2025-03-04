using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Melee;
    public bool isAttacking = false;
    float atkDuration = 0.3f;
    float atkTimer = 0f;
    Animator anim;

    // Update is called once per frame
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        CheckMeleeTimer();

        //Debug.Log("isAttacking : " + isAttacking);

        if(Input.GetMouseButton(0))
        {
            //left click attack
            OnAttack();
        }
    }
    void OnAttack()
    {
        if (!isAttacking)
        {
            Melee.SetActive(true);
            isAttacking = true;
            anim.SetBool("isAttacking", true);
            //call animator to play melee attack
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
                isAttacking = false;
                anim.SetBool("isAttacking", false);
                Melee.SetActive(false);
            }
        }
    }
}

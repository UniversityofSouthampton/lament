using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public enum EnemyState {Idle, Attack, Move,  Die}

public class Enemy_WhisperBehaviour : MonoBehaviour
{
    
    public GameObject player;
    public EnemyState currentState = EnemyState.Attack;

    public float range; 

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case(EnemyState.Idle):
                Attack();
            break;

            case(EnemyState.Attack):
                Attack();
            break;

            case(EnemyState.Move):
                Move();
            break;

            case(EnemyState.Die):
                Die();
            break;
        }
    }

    void Idle()
    {

    }

    void Attack()
    {

    }

    void Move()
    {

    }

    void Die()
    {

    }

}

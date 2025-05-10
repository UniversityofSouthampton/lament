using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonTransition : MonoBehaviour
{
    Animator anim;
    
    AudioManager audioManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("Opening");
            
            audioManager.PlaySfx(audioManager.ambience);
        }
    }

    private void LoadDungeon()
    {
        SceneController.instance.LoadScene("Dungeon");
    }

}

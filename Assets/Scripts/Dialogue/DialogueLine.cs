using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private TMP_Text textHolder;
        [SerializeField] private string input;

        [Header("Time parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        //private bool continueToNextLine = false;
        private void Awake()
        {
            textHolder = GetComponent<TMP_Text>();
            textHolder.text = "";
        }
        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, delay, sound, delayBetweenLines));
        }
        
        /*public void ContinueDialogue()
        {
            continueToNextLine = true;
        }*/
    }
}


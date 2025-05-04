 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private void OnEnable()
        {
            if (gameObject.activeInHierarchy)
            {
                StartDialogue();
                Debug.Log("Dialogue has been activated");
            }
            
        }

        public void StartDialogue()
        {
            StartCoroutine(dialogueSequence());
            Debug.Log("Dialogue Sequence has commenced");
        }
        private IEnumerator dialogueSequence()
        {
            for(int i = 0; i <transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            gameObject.SetActive(false); 
        }

        private void Deactivate()
        {

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}


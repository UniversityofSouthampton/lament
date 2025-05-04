using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSignalTrigger : MonoBehaviour
{
    public GameObject dialogueHolder;

    public void ActivateDialogueHolder()
    {
        dialogueHolder.SetActive(true);
        Debug.Log("Dialogue Holder is Active");
    }
}

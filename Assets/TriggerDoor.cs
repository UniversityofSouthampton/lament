using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public string DoorCloseAnimationParam = "DoorClose";
    
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void RoomCleared()
    {
        animator.SetBool(DoorCloseAnimationParam, false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool(DoorCloseAnimationParam, true);
    }
    
    
}

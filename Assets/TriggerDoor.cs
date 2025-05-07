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
    public void OpenDoor()
    {
        animator.SetBool("IsOpen", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("IsOpen", false);
    }

    private void OnEnable()
    {
        CloseDoor();
    }
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    
}

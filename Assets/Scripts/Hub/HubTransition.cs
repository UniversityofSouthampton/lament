using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class HubTransition : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            TransitiontoHub();
        }
    }
    public void TransitiontoHub()
    {
        PlayerStatsManager.Instance.currentHealth = PlayerStatsManager.Instance.maxHealth;
        SceneController.instance.LoadScene("Hub");
    }
}

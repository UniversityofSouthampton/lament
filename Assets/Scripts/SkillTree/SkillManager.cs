using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SkillManager : MonoBehaviour
{
    public SkillSO skillSO;


    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
    }
    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
    }

    private void HandleAbilityPointSpent(SkillSlot slot)
    {
        string skillName = slot.skillSO.skillName;

        switch(skillName)
        {
            case "Max Health Boost":
                PlayerStatsManager.Instance.UpdateMaxHealth(1);
                break;

            case "Max Health Boost 2":
                PlayerStatsManager.Instance.UpdateMaxHealth(1);
                break;

            case "Movespeed Boost":
                PlayerStatsManager.Instance.UpdateMovespeed(0.2f);
                break;

            case "TerraShard Boost":
                PlayerStatsManager.Instance.UpdateTerrashardPickup(2);
                break;

            case "TerraShard Boost 2":
                PlayerStatsManager.Instance.UpdateTerrashardPickup(4);
                break;

            case "Damage Boost":
                PlayerStatsManager.Instance.UpdateDamage(0.5f);
                break;
            
            case "Damage Boost 2":
                PlayerStatsManager.Instance.UpdateDamage(0.5f);
                break;

            case "Unlock Key":
                PlayerStatsManager.Instance.UnlockKey();
                Debug.Log("Player has the boss key!");
                break;

            default:
                Debug.LogWarning("Unknown skill: " + skillName);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            default:
                Debug.LogWarning("Unkown skill: " + skillName);
                break;
        }
    }
}

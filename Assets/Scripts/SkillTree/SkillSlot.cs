using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
using UnityEditor.PackageManager;

public class SkillSlot : MonoBehaviour
{
    public List<SkillSlot> prerequisiteSkillSlots;
    public SkillSO skillSO;

    public int currentLevel;
    public bool isUnlocked;

    public Image skillIcon;
    public Button skillButton;
    public TMP_Text skillLevelText;
    
    public static event Action<SkillSlot> OnAbilityPointSpent;
    public static event Action<SkillSlot> OnSkillMaxed;

    public void OnEnable()
    {
        //If a skill is unlocked by default, skip check through PlayerStatsManager
        if (!isUnlocked)
        {
            isUnlocked = PlayerStatsManager.Instance.IsSkillUnlocked(skillSO);
            currentLevel = PlayerStatsManager.Instance.GetSkillLevel(skillSO); //if locked, returns 0
        }

        UpdateUI();
    }

    public void OnValidate()
    {
        if(skillSO != null && skillLevelText != null)
        {
            UpdateUI();
        }
    }

    public void TryUpgradeSkill()
    {
        if(isUnlocked && currentLevel < skillSO.maxLevel)
        {
            currentLevel += skillSO.totalCost;
            OnAbilityPointSpent?.Invoke(this);

            if(currentLevel >= skillSO.maxLevel)
            {
                OnSkillMaxed?.Invoke(this);
            }
            PlayerStatsManager.Instance.UpdateUnlockedSkillDictionary(skillSO,currentLevel);

            UpdateUI();
        }
    }


    public bool CanUnlockSkill()
    {
        foreach (SkillSlot slot in prerequisiteSkillSlots)
        {
            if(!slot.isUnlocked || slot.currentLevel < slot.skillSO.maxLevel)
            {
                return false;
            }
        }
        return true;
    }


    public void Unlock()
    {
        isUnlocked = true;
        PlayerStatsManager.Instance.UpdateUnlockedSkillDictionary(skillSO,0);
        UpdateUI();
    }


    private void UpdateUI()
    {
        skillIcon.sprite = skillSO.skillIcon;

        if(isUnlocked)
        {
            skillButton.interactable = true;
            skillLevelText.text = currentLevel.ToString() + "/" + skillSO.maxLevel.ToString();
            skillIcon.color = Color.white;
        }
        else
        {
            skillButton.interactable = false;
            skillLevelText.text = "Locked";
            skillIcon.color = Color.grey;
        }
    }

}

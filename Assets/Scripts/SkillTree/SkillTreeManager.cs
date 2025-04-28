using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{

    public SkillSlot[] skillSlots;
    public TMP_Text pointsText;
    [SerializeField] int availablePoints;

    public GameObject player;
    private PlayerInventory playerInventory;

    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed += HandleSkillMaxed;
    }

    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed -= HandleSkillMaxed;
    }


    private void Start()
    {
        availablePoints = PlayerStatsManager.Instance.currentTerraShards;
        foreach (SkillSlot slot in skillSlots)
        {
            slot.skillButton.onClick.AddListener(() => CheckAvailablePoints(slot));
        }
        UpdateAbilityPoints(0);
    }

    private void CheckAvailablePoints(SkillSlot slot)
    {
        if(availablePoints > 0)
        {
            slot.TryUpgradeSkill();
        }
    }


    public void Update()
    {
        availablePoints = PlayerStatsManager.Instance.currentTerraShards;
    }



    private void HandleAbilityPointsSpent(SkillSlot skillSlot)
    {
        if(availablePoints > 0)
        {
            UpdateAbilityPoints(-1);
        }
    }

    private void HandleSkillMaxed(SkillSlot skillSlot)
    {
        foreach (SkillSlot slot in skillSlots)
        {
            if(!slot.isUnlocked && slot.CanUnlockSkill())
            {
                slot.Unlock();
            }
        }
    }


    public void UpdateAbilityPoints(int amount)
    {
        PlayerStatsManager.Instance.currentTerraShards += amount;
        pointsText.text = PlayerStatsManager.Instance.currentTerraShards.ToString();
        Debug.Log("Decreased ability points");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{

    public static PlayerStatsManager Instance;

    public GameObject player;

    [Header("Player Stats")]
    public int currentHealth = 3;
    public int maxHealth = 3;
    
    [Header("Player Inventory")]
    public int currentTerraShards;

    //Holds a dictionary to track unlocked skills and their current level
    public Dictionary<SkillSO, int> unlockedSkills = new Dictionary<SkillSO, int>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("PlayerStatsManager created!");
        }
        else
        {
            Debug.Log("Destroying duplicate PlayerStatsManager");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (maxHealth > 5)
        {
            maxHealth -= 1;
        }
        else if (currentHealth > 5)
        {
            currentHealth -= 1;
        }
    }

    public void UpdateMaxHealth(int amount)
    {
        
        maxHealth += amount;
        currentHealth = maxHealth;
    }

    public void takeTerraShards(int pickupTerraShards)
    {
        currentTerraShards += pickupTerraShards;
        //Debug.Log("Current terra shards:" + currentTerraShards);
    }

    public void UpdateUnlockedSkillDictionary(SkillSO skillSO, int skillLevel)
    {
        if (unlockedSkills.ContainsKey(skillSO))
        {
            unlockedSkills[skillSO] = skillLevel;
            Debug.Log($"Updated unlocked skill dictionary: {skillSO.skillName} at level {skillLevel}" );
        }
        else
        {
            if (unlockedSkills.TryAdd(skillSO, skillLevel))
                Debug.Log($"Registered new unlocked skill: {skillSO.skillName} at level {skillLevel}" );
            else
                Debug.LogError($"Failed to register new unlocked skill: {skillSO.skillName}" );
        }
    }

    public bool IsSkillUnlocked(SkillSO skillSO)
    {
        return unlockedSkills.ContainsKey(skillSO);
    }
    public int GetSkillLevel(SkillSO skillSO)
    {
        return unlockedSkills.TryGetValue(skillSO, out var level) ? level : 0;
    }
    
    public void ClearUnlockedSkills()
    {
        unlockedSkills.Clear();
    }
}

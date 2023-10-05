using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamageManager : MonoBehaviour
{
    [SerializeField] private CharacterStatManager _father;
    [SerializeField] private CharacterStatManager _mother;
    [SerializeField] private CharacterStatManager _sister;
    [SerializeField] private CharacterStatManager _brother;
    [SerializeField] private ZombieDefendManager zombieDefendManager;
    private FrontYardHouseUpgradeManager frontYardHouseUpgradeManager;
    private int randomNumber;
    private byte houseLevel;
    void Start()
    {
        zombieDefendManager.GetComponent<ZombieDefendManager>();
        frontYardHouseUpgradeManager = FindObjectOfType<FrontYardHouseUpgradeManager>();
        
    }

    private void OnEnable() 
    {
        zombieDefendManager.OnZombieDamage += randomAttackChance;
    }
    void Update()
    {
        
    }

    private void randomAttackChance(int zombieHealth)
    {   
        GetHouseLevel();

        double damageToHealth = Math.Floor(zombieHealth / 1.0);
        Debug.Log($"Total damage {damageToHealth}");
        double hitChance = Math.Floor(1.0f);  
        hitChance = (float) hitChance;
        randomNumber = (int) UnityEngine.Random.Range(1, (float)hitChance );
        Debug.Log("Attack Chance: " + randomNumber);
        if(randomNumber <= 60)
        {
            //character.CharacterHealthAdjust(-1);
        }
    }

    private void GetHouseLevel()
    {
        houseLevel = (byte) frontYardHouseUpgradeManager.GetHouseLevel();
    }

    // public void EndRaidButton(GameObject zommbieRaidUI)
    // {
    //     randomAttackChance(_father);
    //     randomAttackChance(_mother);
    //     randomAttackChance(_sister);
    //     randomAttackChance(_brother);
    //     zommbieRaidUI.SetActive(false);        
    // }
}

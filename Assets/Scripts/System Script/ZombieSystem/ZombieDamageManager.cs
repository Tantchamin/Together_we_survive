using System;
using UnityEngine;

public class ZombieDamageManager : MonoBehaviour
{
    [SerializeField] private CharacterStatManager _father;
    [SerializeField] private CharacterStatManager _mother;
    [SerializeField] private CharacterStatManager _sister;
    [SerializeField] private CharacterStatManager _brother;
    [SerializeField] private ZombieDefendManager zombieDefendManager;
    private FrontYardHouseUpgradeManager frontYardHouseUpgradeManager;
    private  byte randomNumber;
    public static event Action<byte> OnZombieHit;
    private byte houseLevel , healthDamage , reducePercentDamage;
    void Start()
    {
        zombieDefendManager.GetComponent<ZombieDefendManager>();
        frontYardHouseUpgradeManager = FindObjectOfType<FrontYardHouseUpgradeManager>();
        
    }

    private void OnEnable() 
    {
        zombieDefendManager.OnZombieDamage += randomAttackChance;
    }

    private void randomAttackChance(int zombieHealth)
    {   
        float currentZombieHealth = zombieHealth;
        GetHouseLevel();
        ReduceDamageByHouseLevel();
        Debug.Log($"Zombie health before damage : {currentZombieHealth}");
        currentZombieHealth = (float) reducePercentDamage / 100.0f * currentZombieHealth;
        Debug.Log($"Reduce percent damage : {reducePercentDamage}");
        Debug.Log($"Current zombie health : {currentZombieHealth}");
        if(currentZombieHealth <= 0) return;

        double damageToHealth = Math.Ceiling(currentZombieHealth / 1.0);
        Debug.Log($"Total damage : {damageToHealth}");
        byte highestHitChance = (byte) Math.Ceiling((float)(10 - reducePercentDamage / 2));
        randomNumber = (byte) UnityEngine.Random.Range(1, highestHitChance);
        Debug.Log($"Highest hit chance : {highestHitChance}");
        Debug.Log("RandomNumber: " + randomNumber);
        if(randomNumber <=  highestHitChance / 2)
        {
            Debug.Log("Zombit hit you");
            OnZombieHit?.Invoke((byte) damageToHealth);
        }
    }

    private void GetHouseLevel()
    {
        houseLevel = (byte) frontYardHouseUpgradeManager.GetHouseLevel();
        Debug.Log($"House level : {houseLevel}");
    }
    private byte ReduceDamageByHouseLevel()
    {
        reducePercentDamage = (byte)((houseLevel == 0) ? 1 :
        (houseLevel == 1) ? 2 : (houseLevel == 2) ? 3 : (houseLevel == 3) ? 5 : 1);
        Debug.Log($"Reduce percent damage : {reducePercentDamage}");
        return reducePercentDamage;
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

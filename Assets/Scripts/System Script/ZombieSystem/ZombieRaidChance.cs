using UnityEngine;
using System;


public class ZombieRaidChance : MonoBehaviour
{
    [SerializeField] private DayManagerScript dayManagerScript;
    [SerializeField] private FrontYardHouseUpgradeManager frontYardHouseUpgradeManager;
    [SerializeField] private float chance; // Min % that it would come
    [SerializeField] private byte days = 5;
    private byte raidedDays = 0;
    private byte breakDays = 3;
    private bool isHouseUpgrading = false;

    public event Action<byte> OnZombieRaid = delegate { };
    [SerializeField] private DayAmountState dayAmountState;
    public enum DayAmountState
    {
        noRaidDays ,
        earlyDays ,
        midDays ,
        lateDays,
        massacreDays, 
        finalDays
    }
    private void Awake() 
    {
        frontYardHouseUpgradeManager = FindObjectOfType<FrontYardHouseUpgradeManager>();
        dayManagerScript = FindObjectOfType<DayManagerScript>();
        dayManagerScript.OnDayStart += ZombieRaidRandomChance;
    }

    private void OnDisable() 
    {
        dayManagerScript.OnDayStart -= ZombieRaidRandomChance;
    }
    public void ZombieRaidRandomChance() // init function of this script
    {
        assignDays();
        float chance = ZombieRaidChanceFromNoise(ZombieRaidChanceFromDays());
        byte randomNumber = (byte) Math.Ceiling( UnityEngine.Random.Range(0.0f , 100.0f));
        Debug.Log("Random chance: " + randomNumber + " , Appear chance: " + chance);
        if(randomNumber <= chance)
        {
            Debug.Log("Raiding");
            Debug.Log(dayAmountState);
            ZombieRaid();
        }

    }
    private void assignDays()
    {
        days = (byte)dayManagerScript.GetDays();
        dayAmountState = (days <=4 ) ? DayAmountState.noRaidDays :
        (days >= 5 && days <= 10) ? DayAmountState.earlyDays :
        (days > 10 && days <= 16) ? DayAmountState.midDays :
        (days > 16 && days <= 22) ? DayAmountState.lateDays :
        (days > 22 && days <= 27) ? DayAmountState.massacreDays :
        (days > 27 && days < 30) ? DayAmountState.noRaidDays : DayAmountState.finalDays;
    }
    public float ZombieRaidChanceFromDays()
    {
        if(dayAmountState == DayAmountState.noRaidDays) return 0;
        if(days - raidedDays <= breakDays) return 0;
        
        chance = (dayAmountState == DayAmountState.earlyDays) ? (float) 20 :
         (dayAmountState == DayAmountState.midDays) ? (float) 30 : 
         (dayAmountState == DayAmountState.lateDays) ? (float) 40 : 
         (dayAmountState == DayAmountState.massacreDays) ? (float) 50 : 
         (dayAmountState == DayAmountState.finalDays) ? (float) 100 : 0;

        return chance;
    }
    private float ZombieRaidChanceFromNoise(float chance)
    {
        if (frontYardHouseUpgradeManager.IsHouseUpgrading())
        {
            Debug.Log($"Chance before upgrading : {chance}");
            chance *= 1.5f;
            Debug.Log($"Chance while upgrading : {chance}");
        }

        return chance;
    } 

    private void ZombieRaid()
    {
        OnZombieRaid(ZombieRaidLevel());
        raidedDays = days;
    }

    private byte ZombieRaidLevel()
    {
        int zombielevel = 0;

        zombielevel = (dayAmountState == DayAmountState.earlyDays) ? 1 :
        (dayAmountState == DayAmountState.midDays) ? UnityEngine.Random.Range (1,2) : 
        (dayAmountState == DayAmountState.lateDays) ? UnityEngine.Random.Range(1,3) :
        (dayAmountState == DayAmountState.massacreDays) ? UnityEngine.Random.Range(3,4) : 
        (dayAmountState == DayAmountState.finalDays) ? 4 : 4;

        return (byte) zombielevel;
    }
}


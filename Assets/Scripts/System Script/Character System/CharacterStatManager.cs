using System;
using UnityEngine;


public class CharacterStatManager : MonoBehaviour
{   

    private bool isDead;
    private byte hungerDailyDecre , thirtstyDailyDecre , energyDailyDecre , healthyDailyDecre , healthDailyDecre, strengthDailyDecre , infectedDailyDecre;
    private CharacterStat characterStat;
    private CharacterStatManager characterStatManager;
    private DayManagerScript DayManagerScript;
    private TemperatureManager temperatureManager;
    public event Action OnHungry , OnThirsty , OnTired , OnWound , OnInfected , OnSick , OnDead;
    public event Action OnStopHungry , OnStopThirsty , OnStopTired , OnStopWound , OnStopInfected , OnStopSick;
    private CharacterState characterState;
    public CharacterTemperatureState characterTemperatureState;

    private byte damage;
    private bool isCharacterGuarding;

    [SerializeField] private bool isImmortal ;
    private enum CharacterState
    {
        Hungry ,
        Thirsty,
        Tired ,
        Wound ,
        Infected , 
        Dead
    }
    public enum CharacterTemperatureState
    {
        Burn ,
        Hot ,
        Normal ,
        Cold ,
        Freeze,

    }

    private void Awake()
    {
        characterStat = GetComponent<CharacterStat>();
        characterStatManager = GetComponent<CharacterStatManager>();
        DayManagerScript = FindObjectOfType<DayManagerScript>();
        temperatureManager = FindObjectOfType<TemperatureManager>();
        DayManagerScript.OnDayStart += DailyStatsDecrease;
        DayManagerScript.OnDayStart += SetDailyHealthDecrease;
        DayManagerScript.OnDayStart += DailyHealthDecrease;

        ZombieDamageManager.OnZombieHit += ZombieHit;
        
    }
    private void OnDisable() 
    {
        DayManagerScript.OnDayStart -= DailyStatsDecrease;
        DayManagerScript.OnDayStart -= SetDailyHealthDecrease;
        DayManagerScript.OnDayStart -= DailyHealthDecrease;

        ZombieDamageManager.OnZombieHit -= ZombieHit;
    }
    private void Start()
    {
        SetDailyDecreaseStats();
        SetDailyHealthDecrease();
    }
    public void Update()
    {
        if(isImmortal == true) return;
        CheckDead();
        CheckHungry();
        CheckThirsty();
        CheckHealth();
        CheckHealthy();
        CheckEnergy();
        CheckInfected();
        if(isDead == true)
        {
            characterStatManager.enabled = false;
        }
    }

    // DAILY STAT CHECKING AND LOSING
    private void DailyStatsDecrease()
    {
        ResetStatDecrease();
        SetDailyDecreaseStats();
        
        // THE THING THAT YOU BASICLLY LOSE DAILY
        if(characterStat.HungryCurrentValue >= 0 && characterStat.IsHungry == false)
        {
            characterStat.DecreHungryValue = hungerDailyDecre;
        }
        if(characterStat.ThirstyCurrentValue >= 0 && characterStat.IsThirsty == false)
        {
            characterStat.DecreThirstyValue = thirtstyDailyDecre;
        }
        if(characterStat.EnergyCurrentValue >= 0 && characterStat.IsTired == false)
        {
            characterStat.DecreEnergyValue = energyDailyDecre;
        }
        if(characterStat.HealthyCurrentValue >= 0 && characterStat.IsFevered == false)
        {
            characterStat.DecreHealthyValue = healthyDailyDecre;
        }
        if(characterStat.StrengthCurrentValue >= 0)
        {
            characterStat.DecreStrengthValue = strengthDailyDecre;
        }
        if(characterStat.InfectedCurrentValue >= 0 && characterStat.IsBitten == true)
        {
            characterStat.DecreInfectedValue = infectedDailyDecre;
        }
        
    }
    
    private void SetDailyDecreaseStats()
    {
        hungerDailyDecre = 2;
        thirtstyDailyDecre = 2;
        CheckIsScavenger();
        CheckIsSick();
        CheckIsInfected();
    }


    private void ResetStatDecrease()
    {
        hungerDailyDecre = 0;
        thirtstyDailyDecre = 0;
        energyDailyDecre = 0; 
        healthyDailyDecre = 0; 
        healthDailyDecre = 0;
        infectedDailyDecre = 0;
    }

    private void CheckIsScavenger()
    {
        // CONDITION 
        energyDailyDecre = 2;

        energyDailyDecre = 0;

    }
    private void CheckIsInfected()
    {
        if(characterStat.IsBitten == true)
        {
            infectedDailyDecre += 2;
        }
    }

    private void CheckIsSick()
    {
        CheckTemperatureLevel();
        healthyDailyDecre = (byte)((characterTemperatureState == CharacterTemperatureState.Normal) ? 0 :
        (characterTemperatureState == CharacterTemperatureState.Cold) ? 1 : 
        (characterTemperatureState == CharacterTemperatureState.Freeze) ? 2 : 
        0);

        Debug.Log("Healthy : "  + healthyDailyDecre);
    }

    private void DailyHealthDecrease()
    {
        characterStat.DecreHealthValue = healthDailyDecre; 
    }

    private void CheckTemperatureLevel()
    {
        float _temperature = temperatureManager.GetTemperature();
        characterTemperatureState = (_temperature >= 35) ? CharacterTemperatureState.Burn :
        (_temperature >= 27 && _temperature <= 34) ? CharacterTemperatureState.Hot :
        (_temperature >= 23 && _temperature <= 26) ? CharacterTemperatureState.Normal :
        (_temperature >= 18 && _temperature <= 22) ? CharacterTemperatureState.Cold :
        (_temperature < 18 ) ? CharacterTemperatureState.Freeze : characterTemperatureState;
    }
    private void SetDailyHealthDecrease()
    {
        healthyDailyDecre = 0;

        if(characterStat.IsHungry)
        {
            healthDailyDecre += 1;
        }
        if(characterStat.IsThirsty)
        {
            healthDailyDecre += 1;
        }
         if(characterStat.IsFevered)
        {
            strengthDailyDecre += 1;
            healthDailyDecre += 2;
        }
        if(characterStat.IsInfected)
        {
            strengthDailyDecre +=2;
            healthDailyDecre += 3;
        }

    }
    // CHECKING SOME STATS 
    private void CheckHungry()
    {
        if(characterStat.HungryCurrentValue <= Math.Floor((double) characterStat.HungryMaxValue / 2))
        {
            OnHungry?.Invoke();
            if(characterStat.HungryCurrentValue <= 0)
            {
                characterStat.IsHungry = true;
            }
        }
        else{
            OnStopHungry?.Invoke();
            characterStat.IsHungry = false;
        }
    }

    private void CheckThirsty()
    {
        if(characterStat.ThirstyCurrentValue <= Math.Floor((double) characterStat.ThirstyMaxValue / 2))
        {
            OnThirsty?.Invoke();
            if(characterStat.ThirstyCurrentValue <= 0)
            {
                characterStat.IsThirsty = true; 
            }
        }
        else{
            OnStopThirsty?.Invoke();
            characterStat.IsThirsty = false;
        }
    }

    private void CheckEnergy()
    {
        if(characterStat.EnergyCurrentValue <= Math.Floor((double) characterStat.HealthyMaxValue / 2))
        {
            OnTired?.Invoke();
            if(characterStat.EnergyCurrentValue <= 0)
            {
                characterStat.IsTired = true;
            }
        }
        else{
            characterStat.IsTired = false;
            OnStopTired?.Invoke();
        }
    }

    private void CheckHealth()
    {
        if(characterStat.HealthCurrentValue <= Math.Floor((double) characterStat.HealthMaxValue / 2))
        {
            OnWound?.Invoke();
            if(characterStat.HealthCurrentValue <= 0)
            {
                CheckDead();
            }
        }
        else{
            OnStopWound?.Invoke();
        }
    }

    private void CheckHealthy()
    {
        if(characterStat.HealthyCurrentValue <= Math.Floor((double) characterStat.HealthyMaxValue / 2))
        {
            OnSick?.Invoke();
            if(characterStat.HealthyCurrentValue <= 0)
            {
                characterStat.IsFevered = true;
            }
        }
        else{
            characterStat.IsFevered = false;
            OnStopSick?.Invoke();
        }
    }
    
    private void CheckInfected()
    {
        if(characterStat.InfectedCurrentValue <= Math.Floor((double) characterStat.InfectedMaxValue / 2))
        {
            OnInfected?.Invoke();
            if(characterStat.InfectedCurrentValue <= 0)
            {
                characterStat.IsInfected = true;
            }
        }
        else{
            OnStopInfected?.Invoke();
            characterStat.IsInfected = false;
        }
    }

    private void CheckDead()
    {
        DeadCondition();
    }

    private bool DeadCondition()
    {
        if(characterStat.HealthCurrentValue <= 0)
        {
            OnDead?.Invoke();
            isDead = true;
            characterStat.SetCharacterDead = true;
            characterStat.enabled =false;
            return true;      
        }

        return false;
    }

    private void ZombieHit(byte damageInput)
    {  
        damage = damageInput;
        ReduceDamageByGuarding();
        Debug.Log($"Got hit {damage} damage");
        characterStat.DecreHealthValue = damage;
    }

    public  void CharacterGuarding(bool _isGuard)
    {
        isCharacterGuarding = _isGuard;
    }
    
    private void ReduceDamageByGuarding()
    {
        string _name = gameObject.name;
        bool _damageReduced = false;
        if(isCharacterGuarding == true)
        {
            Debug.Log($"This {_name} is guarding!");
            damage = (byte) Math.Floor((float) damage / 2.0f);
            _damageReduced = true;
        }
        
        if(isCharacterGuarding == false && _damageReduced == true)
        {
            damage *=2;
            _damageReduced =false;
        }
    }


    // private bool IsCharacterDead()
    // {
    //     isDead = characterStat.IsDead;
    //     return isDead;
    // }

    // private bool IsCharacterHungry()
    // {
    //     return true;
    // }

}

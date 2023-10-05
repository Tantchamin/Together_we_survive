using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CharacterStatManager : MonoBehaviour
{   

    private bool isDead;
    private byte hungerDailyDecre , thirtstyDailyDecre , energyDailyDecre , healthyDailyDecre , healthDailyDecre
    , strengthDailyDecre;
    private CharacterStat characterStat;
    private CharacterStatManager characterStatManager;
    private DayManagerScript dayManagerScript;
    public event Action OnHungry , OnThirsty , OnTired , OnWound , OnInfected , OnSick , OnDead;
    public event Action OnStopHungry , OnStopThirsty , OnStopTired , OnStopWound , OnStopInfected , OnStopSick;
    private CharacterState characterState;
    private enum CharacterState
    {
        Hungry ,
        Thirsty,
        Tired ,
        Wound ,
        Infected , 
        Dead
    }

    private void Awake()
    {
        characterStat = GetComponent<CharacterStat>();
        characterStatManager = GetComponent<CharacterStatManager>();
        dayManagerScript = FindObjectOfType<DayManagerScript>();
        dayManagerScript.OnDayStart += DailyStatsDecrease;
        dayManagerScript.OnDayStart += SetDailyHealthDecrease;
        dayManagerScript.OnDayStart += DailyHealthDecrease;
    }
    private void OnDisable() 
    {
        dayManagerScript.OnDayStart -= DailyStatsDecrease;
        dayManagerScript.OnDayStart -= SetDailyHealthDecrease;
        dayManagerScript.OnDayStart -= DailyHealthDecrease;
    }
    private void Start()
    {
        SetDailyDecreaseStats();
        SetDailyHealthDecrease();
    }
    public void Update()
    {
        
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

    
    private void DailyStatsDecrease()
    {
       
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
    }
    private void DailyHealthDecrease()
    {
        characterStat.DecreHealthValue = healthDailyDecre; 
    }
    private void SetDailyDecreaseStats()
    {
        hungerDailyDecre = 2;
        thirtstyDailyDecre = 2;
        energyDailyDecre = 2;
        healthyDailyDecre = 1;
        strengthDailyDecre = 1;

        
    }

    private void SetDailyHealthDecrease()
    {
        healthyDailyDecre = 0;
        if(characterStat.IsFevered)
        {
            healthDailyDecre += 2;
        }
        if(characterStat.IsHungry)
        {
            healthDailyDecre += 1;
        }
        if(characterStat.IsThirsty)
        {
            healthDailyDecre += 1;
        }
        if(characterStat.IsInfedcted)
        {
            healthDailyDecre += 3;
        }

    }

    private void CheckHungry()
    {
        if(characterStat.HungryCurrentValue <= Math.Floor((double) characterStat.HungryMaxValue / 2))
        {
            OnHungry?.Invoke();
            if(characterStat.HungryCurrentValue == 0)
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
            if(characterStat.ThirstyCurrentValue == 0)
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
            if(characterStat.EnergyCurrentValue == 0)
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
            if(characterStat.HealthCurrentValue == 0)
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
            if(characterStat.HealthyCurrentValue == 0)
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
            if(characterStat.InfectedCurrentValue == 0)
            {
                characterStat.IsInfedcted = true;
            }
        }
        else{
            OnStopInfected?.Invoke();
            characterStat.IsInfedcted = false;
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

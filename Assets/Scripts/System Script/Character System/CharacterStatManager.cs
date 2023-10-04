using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CharacterStatManager : MonoBehaviour
{   

    private bool isDead;
    private byte hungerDailyDecre , thirtstyDailyDecre , energyDailyDecre , healthyDailyDecre
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
    }
    private void OnDisable() 
    {
        dayManagerScript.OnDayStart -= DailyStatsDecrease;
    }
    private void Start()
    {
        SetDailyDecreaseStats();
    }
    private void Update()
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
        characterStat.DecreHungryValue = hungerDailyDecre;
        characterStat.DecreThirstyValue = thirtstyDailyDecre;
        characterStat.DecreEnergyValue = energyDailyDecre;
    }
    private void SetDailyDecreaseStats()
    {
        hungerDailyDecre = 2;
        thirtstyDailyDecre = 2;
        energyDailyDecre = 2;
        healthyDailyDecre = 1;
        strengthDailyDecre = 1;
    }

    private void CheckHungry()
    {
        if(characterStat.HungryCurrentValue <= Math.Floor((double) characterStat.HungryMaxValue / 2))
        {
            OnHungry?.Invoke();
        }
        else{
            OnStopHungry?.Invoke();
        }
    }

    private void CheckThirsty()
    {
        if(characterStat.ThirstyCurrentValue <= Math.Floor((double) characterStat.ThirstyMaxValue / 2))
        {
            OnThirsty?.Invoke();
        }
        else{
            OnStopThirsty?.Invoke();
        }
    }

    private void CheckEnergy()
    {
        if(characterStat.EnergyCurrentValue <= Math.Floor((double) characterStat.HealthyMaxValue / 2))
        {
            OnTired?.Invoke();
        }
        else{
            OnStopTired?.Invoke();
        }
    }

    private void CheckHealth()
    {
        if(characterStat.HealthCurrentValue <= Math.Floor((double) characterStat.HealthMaxValue / 2))
        {
            OnWound?.Invoke();
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
        }
        else{
            OnStopSick?.Invoke();
        }
    }
    
    private void CheckInfected()
    {
        if(characterStat.InfectedCurrentValue <= Math.Floor((double) characterStat.InfectedMaxValue / 2))
        {
            OnInfected?.Invoke();
        }
        else{
            OnStopInfected?.Invoke();
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

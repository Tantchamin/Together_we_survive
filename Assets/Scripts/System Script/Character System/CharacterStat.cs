using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{

    //BOOLEAN 
    [SerializeField] private bool isInjured , isTired , isInfected , isFevered 
    , isHungry , isThirsty ,isHealthy , isDead , isBitten= false;
    public bool IsInjured {get => isInjured;  set => IsInjured = value;}
    public bool IsTired {get => isTired;  set => isTired = value;}
    public bool IsInfected {get => isInfected;  set {isInfected = value;}}
    public bool IsFevered {get => isFevered;  set{isFevered = value;}}
    public bool IsHungry {get => isHungry;  set{isHungry = value;}}
    public bool IsThirsty {get => isThirsty;  set{isThirsty = value;}}
    public bool IsDead {get => isDead;  set{isDead = value;}}
    public bool IsHealthy {get => isHealthy;  set {isHealthy = value;}}
    public bool IsBitten {get => isBitten; set {isBitten = value;}}

    public bool SetCharacterDead {set => isDead = value;}
    public bool SetCharacterTired {set => isTired = value;}
    public bool SetCharacterInfected {set => isInfected =value;}

    [Space(5)]
    [SerializeField] private short healthMaxValue ,healthyMaxValue , hungryMaxValue , thirstyMaxValue , 
    infectedMaxValue , strengthMaxValue , energyMaxValue;

    [TextArea (1,4)]
    public string _textForEditor;
    [SerializeField] private short healthCurrentValue , healthyCurrentValue , hungryCurrentValue , thirstyCurrentValue ,
    infectedCurrentValue , strengthCurrentValue , energyCurrentValue;

    //Health Value
    public short HealthCurrentValue 
        {get => healthCurrentValue;
        set 
        {
            healthCurrentValue = value;
            if(healthCurrentValue >= healthMaxValue)
            {
                healthCurrentValue = healthMaxValue;
            }
            
            if(healthCurrentValue < 0)
            {
                healthCurrentValue = 0;
            }
        }
    }
    public short HealthMaxValue {get => healthMaxValue;}
    public short IncreHealthValue{set => healthCurrentValue += value;}
    public short DecreHealthValue{set => healthCurrentValue -= value;}

    //Healthy Value 
    public short HealthyCurrentValue {get => healthyCurrentValue; 
    set{
        healthyCurrentValue = value;
        if(healthyCurrentValue >= healthyMaxValue)
        {
            healthyCurrentValue = healthyMaxValue;
        }

        if(healthyCurrentValue < 0)
        {
            healthyCurrentValue = 0;
        }
    }
    }
    public short HealthyMaxValue {get => healthyMaxValue;}

    // Hungry Value
    public short HungryCurrentValue {get => hungryCurrentValue; 
    set{
        hungryCurrentValue = value;
        if(hungryCurrentValue >= hungryMaxValue)
        {
            hungryCurrentValue = hungryMaxValue;
        }
        if(hungryCurrentValue < 0)
        {
            hungryCurrentValue = 0;
        }
    }
    }
    public short HungryMaxValue {get => hungryMaxValue;}
    // Thirsty Value
    public short ThirstyCurrentValue {get => thirstyCurrentValue; 
    set{
        thirstyCurrentValue = value;
        if(thirstyCurrentValue >= thirstyMaxValue)
        {
            thirstyCurrentValue = thirstyMaxValue;
        }
        if(thirstyCurrentValue < 0)
        {
            thirstyCurrentValue = 0;
        }
    }
    }
    public short ThirstyMaxValue {get => thirstyMaxValue;}

    //Infect Value
    public short InfectedCurrentValue {get => infectedCurrentValue;
    set{
        infectedCurrentValue =value;
        if(infectedCurrentValue >= infectedMaxValue)
        {
            infectedCurrentValue = infectedMaxValue;
        }
        if(infectedCurrentValue < 0)
        {
            infectedCurrentValue = 0;
        }
    }
    }
    public short InfectedMaxValue {get => infectedMaxValue;}

    // Strength Value
    public short StrengthCurrentValue { get => strengthCurrentValue;
    set{
        strengthCurrentValue = value;
        if(strengthCurrentValue >= strengthMaxValue)
        {
            strengthCurrentValue = strengthMaxValue;
        }
    }}
    public short StrengthMaxValue{ get=> strengthMaxValue;}

    // Energy Value 

    public short EnergyCurrentValue {get => energyCurrentValue;
    set{
        energyCurrentValue = value;
        if(energyCurrentValue> energyMaxValue)
        {
            energyCurrentValue = energyMaxValue;

        }
        else if(energyCurrentValue< 0)
        {
            energyCurrentValue = 0;
        }

        
        
    }}

    public short EnergyMaxValue {get => energyMaxValue;}

    private void Start()
    {
        healthCurrentValue = healthMaxValue;
        healthyCurrentValue = healthyMaxValue;
        hungryCurrentValue = hungryMaxValue;
        thirstyCurrentValue = thirstyMaxValue;
        infectedCurrentValue = infectedMaxValue;
        strengthCurrentValue = strengthMaxValue;
        energyCurrentValue = energyMaxValue;
        
    }
    // private void Update()
    // {
    //     healthCurrentValue = healthMaxValue;
    //     healthyCurrentValue = healthyMaxValue;
    // }
}

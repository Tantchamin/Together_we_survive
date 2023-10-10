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
    }
    }
    public short HealthyMaxValue {get => healthyMaxValue;}
    public short IncreHealthyValue { set => healthyCurrentValue += value;}
    public short DecreHealthyValue {set => healthyCurrentValue -= value;}


    // Hungry Value
    public short HungryCurrentValue {get => hungryCurrentValue; 
    set{
        hungryCurrentValue = value;
        if(hungryCurrentValue >= hungryMaxValue)
        {
            hungryCurrentValue = hungryMaxValue;
        }
    }
    }
    public short HungryMaxValue {get => hungryMaxValue;}
    public short IncreHungryValue {set => hungryCurrentValue += value;}
    public short DecreHungryValue {set => hungryCurrentValue -= value;}

    // Thirsty Value
    public short ThirstyCurrentValue {get => thirstyCurrentValue; 
    set{
        thirstyCurrentValue = value;
        if(thirstyCurrentValue >= thirstyMaxValue)
        {
            thirstyCurrentValue = thirstyMaxValue;
        }
    }
    }
    public short ThirstyMaxValue {get => thirstyMaxValue;}
    public short IncreThirstyValue {set => thirstyCurrentValue += value;}
    public short DecreThirstyValue {set => thirstyCurrentValue -= value;}

    //Infect Value
    public short InfectedCurrentValue {get => infectedCurrentValue;
    set{
        infectedCurrentValue =value;
        if(infectedCurrentValue >= infectedMaxValue)
        {
            infectedCurrentValue = infectedMaxValue;
        }
    }
    }
    public short InfectedMaxValue {get => infectedMaxValue;}
    public short IncreInfectedValue {set => infectedCurrentValue += value;}
    public short DecreInfectedValue { set => infectedCurrentValue -= value;}

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
    public short IncreStrengthValue { set => strengthCurrentValue += value;}
    public short DecreStrengthValue { set => strengthCurrentValue -= value;}

    // Energy Value 

    public short EnergyCurrentValue {get => energyCurrentValue;
    set{
        energyCurrentValue = value;
        if(energyCurrentValue >= energyMaxValue)
        {
            energyCurrentValue = energyMaxValue;
        }
    }}
    public short EnergyMaxValue {get => energyMaxValue;}
    public short IncreEnergyValue {set => energyCurrentValue += value;}
    public short DecreEnergyValue {set => energyCurrentValue -= value;}

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
}

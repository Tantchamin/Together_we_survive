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
    [SerializeField] private short healthCurrentValue , healthyCurrentValue , hungryCurrentValue , thristyCurrentValue ,
    infectedCurrentValue , strengthCurrentValue , energyCurrentValue;

    //Health Value
    public short HealthCurrentValue {get => healthCurrentValue; private set => healthCurrentValue = value;}
    public short HealthMaxValue {get => healthMaxValue;}
    public short IncreHealthValue{set => healthCurrentValue += value;}
    public short DecreHealthValue{set => healthCurrentValue -= value;}

    //Healthy Value 
    public short HealthyCurrentValue {get => healthyCurrentValue; private set => healthyCurrentValue = value;}
    public short HealthyMaxValue {get => healthMaxValue;}
    public short IncreHealthyValue { set => healthyCurrentValue += value;}
    public short DecreHealthyValue {set => healthyCurrentValue -= value;}


    // Hungry Value
    public short HungryCurrentValue {get => hungryCurrentValue; private set => hungryCurrentValue = value;}
    public short HungryMaxValue {get => hungryMaxValue;}
    public short IncreHungryValue {set => hungryCurrentValue += value;}
    public short DecreHungryValue {set => hungryCurrentValue -= value;}

    // Thirsty Value
    public short ThirstyCurrentValue {get => thristyCurrentValue; private set => thristyCurrentValue = value;}
    public short ThirstyMaxValue {get => thirstyMaxValue;}
    public short IncreThirstyValue {set => thristyCurrentValue += value;}
    public short DecreThirstyValue {set => ThirstyCurrentValue -= value;}

    //Infect Value
    public short InfectedCurrentValue {get => infectedCurrentValue; private set => infectedCurrentValue = value;}
    public short InfectedMaxValue {get => infectedMaxValue;}
    public short IncreInfectedValue {set => infectedCurrentValue += value;}
    public short DecreInfectedValue { set => infectedCurrentValue -= value;}

    // Strength Value
    public short StrengthCurrentValue { get => strengthCurrentValue; private set => strengthCurrentValue = value;}
    public short StrengthMaxValue{ get=> strengthMaxValue;}
    public short IncreStrengthValue { set => strengthCurrentValue += value;}
    public short DecreStrengthValue { set => strengthCurrentValue -= value;}

    // Energy Value 

    public short EnergyCurrentValue {get => energyCurrentValue; private set => energyCurrentValue = value;}
    public short EnergyMaxValue {get => energyMaxValue;}
    public short IncreEnergyValue {set => energyCurrentValue += value;}
    public short DecreEnergyValue {set => energyCurrentValue -= value;}

    private void Start()
    {
        healthCurrentValue = healthMaxValue;
        healthyCurrentValue = healthyMaxValue;
        hungryCurrentValue = hungryMaxValue;
        thristyCurrentValue = thirstyMaxValue;
        infectedCurrentValue = infectedMaxValue;
        strengthCurrentValue = strengthMaxValue;
        energyCurrentValue = energyMaxValue;
    }
}

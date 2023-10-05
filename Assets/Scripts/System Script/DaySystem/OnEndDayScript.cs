using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEndDayScript : MonoBehaviour
{

    [SerializeField] private CharacterStat fatherStat, momStat, sisterStat, brotherStat;
    //[SerializeField] private TemperatureManagerScript temperatureManagerScript;
    [SerializeField] private DayManagerScript dayManagerScript;
    int days = 0;

    // private void Awake()
    // {
    //     fatherStat = GameObject.FindWithTag("Father").GetComponent<CharacterStat>();
    //     momStat = GameObject.FindWithTag("Mother").GetComponent<CharacterStat>();
    //     sisterStat = GameObject.FindWithTag("Sister").GetComponent<CharacterStat>();
    //     brotherStat = GameObject.FindWithTag("Brother").GetComponent<CharacterStat>();
    //     dayManagerScript.GetComponent<DayManagerScript>().OnDayEnd += OnEndDayButtonClick;
    // }
    // private void OnDisable() 
    // {
    //     dayManagerScript.GetComponent<DayManagerScript>().OnDayEnd -= OnEndDayButtonClick;
    // }

    // public void OnEndDayButtonClick()
    // {
    //     fatherStat.CharacterHungryAdjust(-2);
    //     momStat.CharacterHungryAdjust(-2);
    //     sisterStat.CharacterHungryAdjust(-2);
    //     brotherStat.CharacterHungryAdjust(-2);

    //     CheckTemperatureLevel();

    //     //_father.CharacterHealthAdjust(-2);
    //     //_mother.CharacterHealthAdjust(-2);
    //     //_sister.CharacterHealthAdjust(-2);
    //     //_brother.CharacterHealthAdjust(-2);

    // }

    // void RandomSickChance(int _chance, CharacterStat character)
    // {
    //     int _sickChance = UnityEngine.Random.Range(1, 101);
    //     Debug.Log("Random Chance: " + _sickChance + " Chance to Sick: " + _chance);
    //     if(_sickChance <= _chance)
    //     {
    //         if(character.GetSick() == false)
    //         {
    //             character.CharacterFeverAdjust(-1);
    //         }
    //     }

    //     if(character.GetSick() == true)
    //     {
    //         character.CharacterFeverAdjust(-2);
    //     }
    // }

    // void CheckTemperatureLevel()
    // {
    //     if(temperatureManagerScript.GetTemperature() <= 22 && temperatureManagerScript.GetTemperature() >= 16)
    //     {
    //         RandomSickChance(15, fatherStat);
    //         RandomSickChance(15, momStat);
    //         RandomSickChance(15, sisterStat);
    //         RandomSickChance(15, brotherStat);
    //     }
    //     else if(temperatureManagerScript.GetTemperature() <= 15)
    //     {
    //         RandomSickChance(30, fatherStat);
    //         RandomSickChance(30, momStat);
    //         RandomSickChance(30, sisterStat);
    //         RandomSickChance(30, brotherStat);
    //     }

    //     SetNextDayTemperature();
        
    // }

    void SetNextDayTemperature()
    {
        days = dayManagerScript.GetDays();

        if (days <= 7)
        {
            RandomSetTemperature(20,28);
        }
        else if (days >= 8 && days <= 14)
        {
            RandomSetTemperature(16, 26);
        }
        else if (days >= 15 && days <= 21)
        {
            RandomSetTemperature(12, 22);
        }
        else if (days >= 22 && days <= 29)
        {
            RandomSetTemperature(8, 18);
        }
        else if (days == 30)
        {
            RandomSetTemperature(20, 28);
        }
    }

    void RandomSetTemperature(int _lowestChance, int highestChance)
    {
        int _randomNumber = UnityEngine.Random.Range(_lowestChance, highestChance);
        //temperatureManagerScript.SetTemperature(_randomNumber);
        Debug.Log("Set Temperature: " + _randomNumber);
    }


}

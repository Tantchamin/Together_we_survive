using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEndDayScript : MonoBehaviour
{

    [SerializeField] private CharacterStatScript _father, _mother, _sister, _brother;
    [SerializeField] private TemperatureManagerScript temperatureManagerScript;
    [SerializeField] private DayManagerScript dayManagerScript;
    int _day = 1;

    private void Start()
    {
        _father = GameObject.FindWithTag("Father").GetComponent<CharacterStatScript>();
        _mother = GameObject.FindWithTag("Mother").GetComponent<CharacterStatScript>();
        _sister = GameObject.FindWithTag("Sister").GetComponent<CharacterStatScript>();
        _brother = GameObject.FindWithTag("Brother").GetComponent<CharacterStatScript>();
    }

    public void OnEndDayButtonClick()
    {
        _father.CharacterHungryAdjust(-2);
        _mother.CharacterHungryAdjust(-2);
        _sister.CharacterHungryAdjust(-2);
        _brother.CharacterHungryAdjust(-2);

        CheckTemperatureLevel();

        //_father.CharacterHealthAdjust(-2);
        //_mother.CharacterHealthAdjust(-2);
        //_sister.CharacterHealthAdjust(-2);
        //_brother.CharacterHealthAdjust(-2);

    }

    void RandomSickChance(int _chance, CharacterStatScript _character)
    {
        int _sickChance = Random.Range(1, 101);
        Debug.Log("Random Chance: " + _sickChance + " Chance to Sick: " + _chance);
        if(_sickChance <= _chance)
        {
            if(_character.GetSick() == false)
            {
                _character.CharacterFeverAdjust(-1);
            }
        }

        if(_character.GetSick() == true)
        {
            _character.CharacterFeverAdjust(-2);
        }
    }

    void CheckTemperatureLevel()
    {
        if(temperatureManagerScript.GetTemperature() <= 22 && temperatureManagerScript.GetTemperature() >= 16)
        {
            RandomSickChance(15, _father);
            RandomSickChance(15, _mother);
            RandomSickChance(15, _sister);
            RandomSickChance(15, _brother);
        }
        else if(temperatureManagerScript.GetTemperature() <= 15)
        {
            RandomSickChance(30, _father);
            RandomSickChance(30, _mother);
            RandomSickChance(30, _sister);
            RandomSickChance(30, _brother);
        }

        SetNextDayTemperature();
        
    }

    void SetNextDayTemperature()
    {
        _day = dayManagerScript.GetDay();

        if (_day <= 7)
        {
            RandomSetTemperature(20,28);
        }
        else if (_day >= 8 && _day <= 14)
        {
            RandomSetTemperature(16, 26);
        }
        else if (_day >= 15 && _day <= 21)
        {
            RandomSetTemperature(12, 22);
        }
        else if (_day >= 22 && _day <= 29)
        {
            RandomSetTemperature(8, 18);
        }
        else if (_day == 30)
        {
            RandomSetTemperature(20, 28);
        }
    }

    void RandomSetTemperature(int _lowestChance, int highestChance)
    {
        int _randomNumber = Random.Range(_lowestChance, highestChance);
        temperatureManagerScript.SetTemperature(_randomNumber);
        Debug.Log("Set Temperature: " + _randomNumber);
    }


}

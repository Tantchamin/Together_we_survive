using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatScript : MonoBehaviour
{
    // boolean for enable stat deduction
    [SerializeField] private bool _isInjured = false;
    [SerializeField] private bool _isTired = false;
    [SerializeField] private bool _isInfected = false;
    [SerializeField] private bool _isFevered = false;
    [SerializeField] private bool _isHungry = false;
    [SerializeField] private bool _isThirsty = false;
    [SerializeField] private bool _isDead = false;

    [SerializeField] private int _healthyMaxValue;
    private int _healthyValue;

    [SerializeField] private int _hungryMaxValue;
    private int _hungryValue;

    [SerializeField] private int _thirstyMaxValue;
    private int _thirstyValue;

    [SerializeField] private int _infectedMaxValue;
    private int _infectedValue;

    [SerializeField] private int _StrengthMaxValue;
    private int _strengthValue;
    [SerializeField] private int _healthMaxValue;
    private int _healthValue;
    [SerializeField] private List<int> _characterStat;
    void Start()
    {
        _healthyValue = _healthyMaxValue;
        _hungryValue = _hungryMaxValue;
        _thirstyValue = _thirstyMaxValue;
        _strengthValue = _StrengthMaxValue;
        _healthValue = _healthMaxValue;

        _characterStat.Add(_healthyValue);
        _characterStat.Add(_hungryValue);
        _characterStat.Add(_thirstyValue);
        _characterStat.Add(_healthValue);
        _characterStat.Add(_infectedValue);
        _characterStat.Add(_strengthValue);

    }
    void Update()
    {
        if (_characterStat[0] == _healthyMaxValue || _isDead == true)
        {
            _isFevered = false;
        }
        else
        {
            _isFevered = true;
        }

        if (_characterStat[1] == _hungryMaxValue || _isDead == true)
        {
            _isHungry = false;
        }
        else
        {
            _isHungry = true;
        }

        if (_characterStat[2] == _thirstyMaxValue || _isDead == true)
        {
            _isThirsty = false;
        }
        else
        {
            _isThirsty = true;
        }

        if (_characterStat[3] == _healthMaxValue || _isDead == true)
        {
            _isInjured = false;
        }
        else
        {
            _isInjured = true;
        }

        if (_characterStat[0] <= 0 || _characterStat[1] <= 0 || _characterStat[2] <= 0 || _characterStat[3] <= 0)
        {
            _isDead = true;
        }


    }

    public void CharacterHealthAdjust(int value)
    {
        //_isInjured = true;
        _characterStat[3] += value;
        //if (_healthValue == _healthMaxValue)
        //{
        //    _isInjured = false;
        //}
    }

    public void CharacterHungryAdjust(int value)
    {
        //_isHungry = true;
        _characterStat[1] += value;
        //if (_hungryValue == _hungryMaxValue)
        //{
        //    _isHungry = false;
        //}
    }

    public void CharacterThirstyAdjust(int value)
    {
        //_isThirsty = true;
        _characterStat[2] += value;
        //if (_thirstyValue == _thirstyMaxValue)
        //{
        //    _isThirsty = false;
        //}
    }

    public void CharacterFeverAdjust(int value)
    {
        //_isFevered = true;
        _characterStat[0] += value;
        //if (_healthyValue == _healthyMaxValue)
        //{
        //    _isFevered = false;
        //}
    }

    public void CharacterInfectedAdjust(int value)
    {
        _isInfected = true;
        _infectedValue += value;
    }

    public void SetCharacterTire(bool isTire)
    {
        _isTired = isTire;
    }

    public void SetCharacterDead(bool isDeadYet)
    {
        _isDead = isDeadYet;
    }

    public int GetCharacterStat(int _indexArray)
    {

        return _characterStat[_indexArray];

    }

    public bool GetTired()
    {
        return _isTired;
    }

    public bool GetInjured()
    {
        return _isInjured;
    }

    public bool GetSick()
    {
        return _isFevered;
    }

    public bool GetInfected()
    {
        return _isInfected;
    }

    public bool GetHungry()
    {
        return _isHungry;
    }

    public bool GetThirsty()
    {
        return _isThirsty;
    }
    public bool GetIsDead()
    {
        return _isDead;
    }


}

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

    [SerializeField] private byte _healthyMaxValue;
    private byte _healthyValue;

    [SerializeField] private byte _hungryMaxValue;
    private byte _hungryValue;

    [SerializeField] private byte _thirstyMaxValue;
    private byte _thirstyValue;

    [SerializeField] private byte _infectedMaxValue;
    private byte _infectedValue;

    [SerializeField] private byte _StrengthMaxValue;
    private byte _strengthValue;
    [SerializeField] private byte _healthMaxValue;
    private byte _healthValue;
    [SerializeField] private List<byte> _characterStat;
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
        if (_characterStat[0] == _healthyMaxValue)
        {
            _isFevered = false;
        }
        else
        {
            _isFevered = true;
        }

        if (_characterStat[1] == _hungryMaxValue)
        {
            _isHungry = false;
        }
        else
        {
            _isHungry = true;
        }

        if (_characterStat[2] == _thirstyMaxValue)
        {
            _isThirsty = false;
        }
        else
        {
            _isThirsty = true;
        }

        if (_characterStat[3] == _healthMaxValue)
        {
            _isInjured = false;
        }
        else
        {
            _isInjured = true;
        }

    }

    public void CharacterHealthAdjust(byte value)
    {
        _isInjured = true;
        _healthValue += value;
        if (_healthValue == _healthMaxValue)
        {
            _isInjured = false;
        }
    }

    public void CharacterHungryAdjust(byte value)
    {
        _isHungry = true;
        _hungryValue += value;
        if (_hungryValue == _hungryMaxValue)
        {
            _isHungry = false;
        }
    }

    public void CharacterThirstyAdjust(byte value)
    {
        _isThirsty = true;
        _thirstyValue += value;
        if (_thirstyValue == _thirstyMaxValue)
        {
            _isThirsty = false;
        }
    }

    public void CharacterFeverAdjust(byte value)
    {
        _isFevered = true;
        _healthyValue += value;
        if (_healthyValue == _healthyMaxValue)
        {
            _isFevered = false;
        }
    }

    public void CharacterInfectedAdjust(byte value)
    {
        _isInfected = true;
        _infectedValue += value;
    }

    public void SetCharacterTire(bool isTire)
    {
        _isTired = isTire;
    }

    public byte GetCharacterStat(int _indexArray)
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

}

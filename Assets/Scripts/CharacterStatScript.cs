using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatScript : MonoBehaviour
{
    // boolean for enable stat deduction
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
        _characterStat.Add(_strengthValue);
        _characterStat.Add(_healthValue);

    }
    void Update()
    {

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
        
    }

    public void SetCharacterTire(bool isTire)
    {
        _isTired = isTire;
    }

    public byte GetCharacterStat(int _indexArray)
    {

        return _characterStat[_indexArray];

    }
}

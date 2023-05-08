using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacterManagerScript : MonoBehaviour
{
    [SerializeField] private Toggle _isFatherScavenger;
    [SerializeField] private Toggle _isFatherGuard;
    [SerializeField] private Toggle _isFatherSleep;
    [SerializeField] private Toggle _isMotherScavenger;
    [SerializeField] private Toggle _isMotherGuard;
    [SerializeField] private Toggle _isMotherSleep;
    [SerializeField] private Toggle _isSisterScavenger;
    [SerializeField] private Toggle _isSisterGuard;
    [SerializeField] private Toggle _isSisterSleep;
    [SerializeField] private Toggle _isBrotherScavenger;
    [SerializeField] private Toggle _isBrotherGuard;
    [SerializeField] private Toggle _isBrotherSleep;

    // Start is called before the first frame update
    void Start()
    {
        _isFatherScavenger.isOn = false;
        _isFatherGuard.isOn = false;
        _isFatherSleep.isOn = false;
        _isMotherScavenger.isOn = false;
        _isMotherGuard.isOn = false;
        _isMotherSleep.isOn = false;
        _isSisterScavenger.isOn = false;
        _isSisterGuard.isOn = false;
        _isSisterSleep.isOn = false;
        _isBrotherScavenger.isOn = false;
        _isBrotherGuard.isOn = false;
        _isBrotherSleep.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacterManagerScript : MonoBehaviour
{
    [SerializeField] private List<Toggle> _fatherToggleList;
    [SerializeField] private List<Toggle> _motherToggleList;
    [SerializeField] private List<Toggle> _sisterToggleList;
    [SerializeField] private List<Toggle> _brotherToggleList;
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
    [SerializeField] private Button _nextMapButton;
    bool _isFatherToggle = false;
    bool _isMotherToggle = false;
    bool _isSisterToggle = false;
    bool _isBrotherToggle = false;
    int _fatherScavengerCounter = 0;
    int _motherScavengerCounter = 0;
    int _sisterScavengerCounter = 0;
    int _brotherScavengerCounter = 0;
    bool _isOnlyScavenger = false;


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

        //foreach (Toggle _toggle in _fatherToggleList)
        //{
        //    _toggle.isOn = false;
        //}
        //foreach (Toggle _toggle in _motherToggleList)
        //{
        //    _toggle.isOn = false;
        //}
        //foreach (Toggle _toggle in _sisterToggleList)
        //{
        //    _toggle.isOn = false;
        //}
        //foreach (Toggle _toggle in _brotherToggleList)
        //{
        //    _toggle.isOn = false;
        //}
    }

    private void Update()
    {
        // ToggleList
        if (_isFatherScavenger.isOn == false && _isFatherGuard.isOn == false && _isFatherSleep.isOn == false)
        {
            _nextMapButton.interactable = false;
        }
        else
        {
            _isFatherToggle = true;
        }

        if (_isMotherScavenger.isOn == false && _isMotherGuard.isOn == false && _isMotherSleep.isOn == false)
        {
            _nextMapButton.interactable = false;
        }
        else
        {
            _isMotherToggle = true;
        }

        if (_isSisterScavenger.isOn == false && _isSisterGuard.isOn == false && _isSisterSleep.isOn == false)
        {
            _nextMapButton.interactable = false;
        }
        else
        {
            _isSisterToggle = true;
        }

        if (_isBrotherScavenger.isOn == false && _isBrotherGuard.isOn == false && _isBrotherSleep.isOn == false)
        {
            _nextMapButton.interactable = false;
        }
        else
        {
            _isBrotherToggle = true;
        }

        if (_isFatherToggle == true && _isMotherToggle == true && _isSisterToggle == true && _isBrotherToggle == true && _isOnlyScavenger == true)
        {
            _nextMapButton.interactable = true;
        }

        // Check scavenger is there more than 2 scavenger
        if (_isFatherScavenger.isOn == true)
        {
            _fatherScavengerCounter = 1;
        }
        else
        {
            _fatherScavengerCounter = 0;
        }

        if (_isMotherScavenger.isOn == true)
        {
            _motherScavengerCounter = 1;
        }
        else
        {
            _motherScavengerCounter = 0;
        }

        if (_isSisterScavenger.isOn == true)
        {
            _sisterScavengerCounter = 1;
        }
        else
        {
            _sisterScavengerCounter = 0;
        }

        if (_isBrotherScavenger.isOn == true)
        {
            _brotherScavengerCounter = 1;
        }
        else
        {
            _brotherScavengerCounter = 0;
        }

        if(_fatherScavengerCounter + _motherScavengerCounter +_sisterScavengerCounter+ _brotherScavengerCounter <= 1)
        {
           _isOnlyScavenger = true;
        }
        else
        {
            _isOnlyScavenger = false;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterLabelScript : MonoBehaviour
{
    [SerializeField] private GameObject _mapLabel;
    [SerializeField] private DayManagerScript _dayManagerScript;
    [SerializeField] private ZombieRaidChance _zombieManager;
    ChooseCharacterManagerScript _chooseCharacterManagerScript;

    private void Start()
    {
        _chooseCharacterManagerScript = GameObject.FindGameObjectWithTag("ChooseCharacterManager").GetComponent<ChooseCharacterManagerScript>();
        _dayManagerScript =FindObjectOfType<DayManagerScript>();
        _zombieManager = FindObjectOfType<ZombieRaidChance>();
    }

    public void NextButton()
    {
        if (_chooseCharacterManagerScript.IsHaveScavenger() == true)
        {
            _mapLabel.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
            _zombieManager.ZombieRaidChanceFromDays();
            
        }
    }
}

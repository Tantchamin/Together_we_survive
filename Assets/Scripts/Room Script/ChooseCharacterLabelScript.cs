using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterLabelScript : MonoBehaviour
{
    [SerializeField] private GameObject _mapLabel;
    [SerializeField] private DayManagerScript _dayManagerScript;
    [SerializeField] private ZombieRaidChance zombieRaidChance;
    ChooseCharacterManagerScript _chooseCharacterManagerScript;

    private void Start()
    {
        _chooseCharacterManagerScript = GameObject.FindGameObjectWithTag("ChooseCharacterManager").GetComponent<ChooseCharacterManagerScript>();
        _dayManagerScript =FindObjectOfType<DayManagerScript>();
        zombieRaidChance = FindObjectOfType<ZombieRaidChance>();

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
            zombieRaidChance.ZombieRaidChanceFromDays();
            _dayManagerScript.IncreaseDays();
        }
    }
}

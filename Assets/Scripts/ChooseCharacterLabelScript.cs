using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterLabelScript : MonoBehaviour
{
    [SerializeField] private GameObject _mapLabel;
    [SerializeField] private DayManagerScript _dayManagerScript;
    [SerializeField] private ZombieManagerScript _zombieManager;
    ChooseCharacterManagerScript _chooseCharacterManagerScript;

    private void Start()
    {
        _chooseCharacterManagerScript = GameObject.FindGameObjectWithTag("ChooseCharacterManager").GetComponent<ChooseCharacterManagerScript>();
        _dayManagerScript.GetComponent<DayManagerScript>();
        _zombieManager.GetComponent<ZombieManagerScript>();
    }

    public void NextButton()
    {
        if (_chooseCharacterManagerScript.IsHaveScavenger() == true)
        {
            _mapLabel.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
            _zombieManager.ZombieRaidChanceAfterEndDay();
            _dayManagerScript.DayIncrese(1);
            
        }
    }
}

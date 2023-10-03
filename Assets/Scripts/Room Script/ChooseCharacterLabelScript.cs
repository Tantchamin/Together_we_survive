using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterLabelScript : MonoBehaviour
{
    [SerializeField] private GameObject _mapLabel;
    [SerializeField] private DayManagerScript dayManagerScript;
    ChooseCharacterManagerScript _chooseCharacterManagerScript;

    private void Start()
    {
        _chooseCharacterManagerScript = GameObject.FindGameObjectWithTag("ChooseCharacterManager").GetComponent<ChooseCharacterManagerScript>();
        dayManagerScript =FindObjectOfType<DayManagerScript>();

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
            dayManagerScript.IncreaseDays();
            
        }
    }
}

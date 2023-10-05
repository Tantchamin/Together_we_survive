using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNextButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject _mapLabel;
    [SerializeField] private DayManagerScript dayManagerScript;
    ChooseCharacterManager chooseCharacterManager;

    private void Start()
    {
        chooseCharacterManager = GameObject.FindGameObjectWithTag("ChooseCharacterManager").
        GetComponent<ChooseCharacterManager>();
        dayManagerScript =FindObjectOfType<DayManagerScript>();

    }

    public void NextButton()
    {
        if (chooseCharacterManager.IsHaveScavenger() == true)
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

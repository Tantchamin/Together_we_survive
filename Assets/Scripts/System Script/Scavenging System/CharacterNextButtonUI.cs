using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNextButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject mapLabel , inventoryLabel;
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
            inventoryLabel.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
            dayManagerScript.IncreaseDays();
            
        }
    }
}

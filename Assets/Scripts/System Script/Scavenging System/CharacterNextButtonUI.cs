using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNextButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject mapLabel , inventoryLabel;
    ChooseCharacterManager chooseCharacterManager;

    private void Start()
    {
        chooseCharacterManager = GameObject.FindGameObjectWithTag("ChooseCharacterManager").
        GetComponent<ChooseCharacterManager>();

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
            DayManagerScript.IncreaseDays();
            
        }
    }
}

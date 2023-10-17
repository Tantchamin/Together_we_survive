using System;
using UnityEngine;

public class CharacterNextButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryLabel;
    ChooseCharacterManager chooseCharacterManager;
    private CharacterStat scravengerStat;

    public static event Action<CharacterStat> OnScravengerInvoke;
    
    private void OnEnable() {
        ChooseCharacterManager.OnFatherStat += ScravengerCharacterStat;
        ChooseCharacterManager.OnBrotherStat += ScravengerCharacterStat;
        ChooseCharacterManager.OnMotherStat += ScravengerCharacterStat;
        ChooseCharacterManager.OnSisterStat += ScravengerCharacterStat;
    }

    private void OnDisable() {
        ChooseCharacterManager.OnFatherStat -= ScravengerCharacterStat;
        ChooseCharacterManager.OnBrotherStat -= ScravengerCharacterStat;
        ChooseCharacterManager.OnMotherStat -= ScravengerCharacterStat;
        ChooseCharacterManager.OnSisterStat -= ScravengerCharacterStat;
    }
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
            OnScravengerInvoke?.Invoke(scravengerStat);
        }
        else
        {
            gameObject.SetActive(false);
            DayManagerScript.IncreaseDays();
            
        }
    }

    private void ScravengerCharacterStat(CharacterStat characterStat)
    {
        scravengerStat = characterStat;
    }
}

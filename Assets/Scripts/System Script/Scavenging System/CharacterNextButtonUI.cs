using System;
using UnityEngine;

public class CharacterNextButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryLabel;
    ChooseCharacterManager chooseCharacterManager;
    private CharacterStat scavengerStat;

    public static event Action<CharacterStat> OnScavengerInvoke;
    
    private void OnEnable() {
        ChooseCharacterManager.OnFatherStat += ScavengerCharacterStat;
        ChooseCharacterManager.OnBrotherStat += ScavengerCharacterStat;
        ChooseCharacterManager.OnMotherStat += ScavengerCharacterStat;
        ChooseCharacterManager.OnSisterStat += ScavengerCharacterStat;
    }

    private void OnDisable() {
        ChooseCharacterManager.OnFatherStat -= ScavengerCharacterStat;
        ChooseCharacterManager.OnBrotherStat -= ScavengerCharacterStat;
        ChooseCharacterManager.OnMotherStat -= ScavengerCharacterStat;
        ChooseCharacterManager.OnSisterStat -= ScavengerCharacterStat;
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
            OnScavengerInvoke?.Invoke(scavengerStat);
        }
        else
        {
            gameObject.SetActive(false);
            DayManagerScript.IncreaseDays();
            
        }
    }

    private void ScavengerCharacterStat(CharacterStat characterStat)
    {
        scavengerStat = characterStat;
    }
}

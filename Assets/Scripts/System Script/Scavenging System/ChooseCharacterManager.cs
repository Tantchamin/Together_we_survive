using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacterManager : MonoBehaviour
{
    [SerializeField] private Toggle isFatherScavenger, isFatherGuard, isFatherSleep;
    [SerializeField] private Toggle isMotherScavenger;
    [SerializeField] private Toggle isMotherGuard;
    [SerializeField] private Toggle isMotherSleep;
    [SerializeField] private Toggle isSisterScavenger;
    [SerializeField] private Toggle isSisterGuard;
    [SerializeField] private Toggle isSisterSleep;
    [SerializeField] private Toggle isBrotherScavenger;
    [SerializeField] private Toggle isBrotherGuard;
    [SerializeField] private Toggle isBrotherSleep;

    [SerializeField] private ToggleGroup fatherToggleGroup , motherToggleGroup , sisterToggleGroup
    , brotherToggleGroup;
    [SerializeField] private Button nextMapButton;
    [SerializeField]private CharacterStat fatherCharacterStat , motherCharacterStat , sisterCharacterStat , brotherCharacterStat;
    [SerializeField] private CharacterStatManager fatherCharacterStatManager , motherCharacterStatManager
    , brotherCharacterStatManager , sisterCharacterStatManager;

    private List<Toggle> guardToggleList = new List<Toggle>();
    bool isFatherToggle = false;
    bool isMotherToggle = false;
    bool isSisterToggle = false;
    bool isBrotherToggle = false;
    byte fatherScavengerCounter = 0;
    byte motherScavengerCounter = 0;
    byte sisterScavengerCounter = 0;
    byte brotherScavengerCounter = 0;
    bool isOnlyScavenger = false;
    private bool isHaveScavenger = false;
    [SerializeField] private byte guardPeopleAmount = 0;

    public static event Action<bool> OnFatherScavenger , OnMotherScavenger , OnBrotherScavenger , OnSisterScavenger;
    public static event Action<CharacterStat> OnFatherStat , OnMotherStat , OnBrotherStat , OnSisterStat;
    public static event Action<bool> OnFatherGuard , OnMotherGuard , OnBrotherGuard , OnSisterGuard;


    private void Awake()
    {
        OnFatherGuard += fatherCharacterStatManager.CharacterGuarding;
        OnMotherGuard += motherCharacterStatManager.CharacterGuarding;
        OnSisterGuard += sisterCharacterStatManager.CharacterGuarding;
        OnBrotherGuard += brotherCharacterStatManager.CharacterGuarding;

        OnFatherScavenger += fatherCharacterStatManager.CharacterScavenging;
        OnMotherScavenger += motherCharacterStatManager.CharacterScavenging;
        OnSisterScavenger += sisterCharacterStatManager.CharacterScavenging;
        OnBrotherScavenger += brotherCharacterStatManager.CharacterScavenging;
    }
        
    void Start()
    {
        isFatherScavenger.isOn = false;
        isFatherGuard.isOn = false;
        isFatherSleep.isOn = true;
        isMotherScavenger.isOn = false;
        isMotherGuard.isOn = false;
        isMotherSleep.isOn = true;
        isSisterScavenger.isOn = false;
        isSisterGuard.isOn = false;
        isSisterSleep.isOn = true;
        isBrotherScavenger.isOn = false;
        isBrotherGuard.isOn = false;
        isBrotherSleep.isOn = true;

        guardToggleList.Add(isFatherGuard);
        guardToggleList.Add(isBrotherGuard);
        guardToggleList.Add(isMotherGuard);
        guardToggleList.Add(isSisterGuard);

    }

    
    public void Update()
    {  
        CheckAllToggleList();
        DisableToggleGroup();
    }

    private void CheckAllToggleList()
    {
        isFatherToggle = CheckFatherToogleList();
        isMotherToggle = CheckMotherToggleList();
        isBrotherToggle = CheckBrotherToggleList();
        isSisterToggle = CheckSisterToogleList();
        CheckAllCondition();
        CheckFatherScavenger();
        CheckMotherScavenger();
        CheckBrotherScavenger();
        CheckSisterScavenger();
        GetGuardPeopleAmount();
        CheckScavengerCondition();
    }

    private void DisableToggleGroup()
    {
        if(fatherCharacterStat.IsDead == true)
        {
            isFatherGuard.isOn = false;
            isFatherScavenger.isOn = false;
            fatherToggleGroup.enabled = false;
            fatherToggleGroup.gameObject.SetActive(false);
        }
        if(motherCharacterStat.IsDead == true)
        {
            isMotherGuard.isOn = false;
            isMotherScavenger.isOn =false;
            motherToggleGroup.enabled = false;
            motherToggleGroup.gameObject.SetActive(false);
        }
        if(sisterCharacterStat.IsDead == true)
        {
            isSisterGuard.isOn = false;
            isMotherScavenger.isOn = false;
            sisterToggleGroup.enabled = false;
            sisterToggleGroup.gameObject.SetActive(false);
        }
        if(brotherCharacterStat.IsDead == true)
        {
            isBrotherGuard.isOn = false;
            isMotherScavenger.isOn = false;
            brotherToggleGroup.enabled = false;
            brotherToggleGroup.gameObject.SetActive(false);
        }
    }

    private bool CheckFatherToogleList()
    {
        if(fatherToggleGroup.isActiveAndEnabled == false) return true;
        if(fatherCharacterStat.IsTired == true)
        {
            isFatherScavenger.interactable = false;
            isFatherGuard.interactable = false;
            isFatherGuard.isOn = false;
            isFatherScavenger.isOn = false;
        }
        else
        {
            isFatherScavenger.interactable = true;
            isFatherGuard.interactable = true;
        }

        if (isFatherScavenger.isOn == false && isFatherGuard.isOn == false && isFatherSleep.isOn == false)
        {
            NextMapInteraction(false);
            return false;
        }
        else if(isFatherGuard.isOn == true)
        {
            OnFatherGuard?.Invoke(true);
            return true;
        }
        else
        {
            OnFatherGuard?.Invoke(false);
            return true;
        }

    }

    private bool CheckMotherToggleList()
    {
        if(motherToggleGroup.isActiveAndEnabled == false) return true;
        if(motherCharacterStat.IsTired == true)
        {
            isMotherScavenger.interactable = false;
            isMotherScavenger.isOn = false;
            isMotherGuard.interactable = false;
            isMotherGuard.isOn = false;
        }
        else
        {
            isMotherScavenger.interactable = true;
            isMotherGuard.interactable = true;
        }

        if (isMotherScavenger.isOn == false && isMotherGuard.isOn == false && isMotherSleep.isOn == false)
        {
            NextMapInteraction(false);
            return false;
        }
        else if(isMotherGuard.isOn == true)
        {
            OnMotherGuard?.Invoke(true);
            return true;
        }
        else
        {
            OnMotherGuard?.Invoke(false);
            return true;
        }
    }
    private bool CheckBrotherToggleList()
    {
        if(brotherToggleGroup.isActiveAndEnabled == false) return true;
        if(brotherCharacterStat.IsTired == true)
        {
            isBrotherScavenger.interactable = false;
            isBrotherScavenger.isOn = false;
            isBrotherGuard.interactable =false;
            isBrotherGuard.isOn = false;
        }
        else
        {
            isBrotherScavenger.interactable = true;
            isBrotherGuard.interactable = true;
        }

        if (isBrotherScavenger.isOn == false && isBrotherGuard.isOn == false && isBrotherSleep.isOn == false)
        {
            NextMapInteraction(false);
            return false;
        }
        else if(isBrotherGuard.isOn == true)
        {
            OnBrotherGuard?.Invoke(true);
            return true;
        }
        else
        {
            OnBrotherGuard?.Invoke(false);
            return true;
        }
    }

    private bool CheckSisterToogleList()
    {
        if(sisterToggleGroup.isActiveAndEnabled == false) return true;
        if(sisterCharacterStat.IsTired == true)
        {
            isSisterScavenger.interactable = false;
            isSisterScavenger.isOn = false;
            isSisterGuard.interactable = false;
            isSisterGuard.isOn = false;
        }
        else
        {
            isSisterScavenger.interactable = true;
            isSisterGuard.interactable = true;
        }
        
        if (isSisterScavenger.isOn == false && isSisterGuard.isOn == false && isSisterSleep.isOn == false)
        {
            NextMapInteraction(false);
            return false;
        }
        else if(isSisterGuard.isOn == true)
        {
            OnSisterGuard?.Invoke(true);
            return true;
        }
        else
        {
            OnSisterGuard?.Invoke(false);
            return true;
        }
    }

    private void NextMapInteraction(bool _enabled)
    {
        nextMapButton.interactable = _enabled;
    }

    private void CheckFatherScavenger()
    {
        if (isFatherScavenger.isOn == true)
        {
            fatherScavengerCounter = 1;
            OnFatherScavenger?.Invoke(true);
            OnFatherStat?.Invoke(fatherCharacterStat);

        }
        else
        {
            fatherScavengerCounter = 0;
            OnFatherScavenger?.Invoke(false);
        }
    }

    private void CheckMotherScavenger()
    {
        if (isMotherScavenger.isOn == true)
        {
            motherScavengerCounter = 1;
            OnMotherScavenger?.Invoke(true);
            OnMotherStat?.Invoke(motherCharacterStat);
        }
        else
        {
            motherScavengerCounter = 0;
            OnMotherScavenger?.Invoke(false);
        }
    }

    private void CheckBrotherScavenger()
    {
        if (isBrotherScavenger.isOn == true)
        {
            brotherScavengerCounter = 1;
            OnBrotherScavenger?.Invoke(true);
            OnBrotherStat?.Invoke(brotherCharacterStat);
        }
        else
        {
            brotherScavengerCounter = 0;
            OnBrotherScavenger?.Invoke(false);
        }
        
    }

    private void CheckSisterScavenger()
    {
        if (isSisterScavenger.isOn == true)
        {
            sisterScavengerCounter = 1;
            OnSisterScavenger?.Invoke(true);
            OnSisterStat?.Invoke(sisterCharacterStat);
        }
        else
        {
            sisterScavengerCounter = 0;
            OnSisterScavenger?.Invoke(false);
        }
    }

    private void CheckScavengerCondition()
    {
        if(fatherScavengerCounter + motherScavengerCounter +sisterScavengerCounter+ brotherScavengerCounter == 1)
        {
           isOnlyScavenger = true;
           isHaveScavenger = true;
        }
        else if(fatherScavengerCounter + motherScavengerCounter + sisterScavengerCounter + brotherScavengerCounter == 0)
        {
            // there is no scavenger here
            isOnlyScavenger = true;
            isHaveScavenger = false;
        }
        else
        {
            isOnlyScavenger = false;
            isHaveScavenger = false;
        }
    }
    private void CheckAllCondition()
    {
        if (isFatherToggle == true && isMotherToggle == true && isSisterToggle == true && isBrotherToggle == true && isOnlyScavenger == true)
        {
            NextMapInteraction(true);
        }
        else
        {
            NextMapInteraction(false);
        }
    }

    public bool IsHaveScavenger()
    {
        return isHaveScavenger;
    }

    public byte GetGuardPeopleAmount()
    {
        guardPeopleAmount = 0;
        foreach(Toggle guardToggle in guardToggleList)
        {
            if(guardToggle.isOn == true) guardPeopleAmount +=1;
        }

        
        return guardPeopleAmount;
    }

}

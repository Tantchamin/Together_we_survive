using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacterManagerScript : MonoBehaviour
{
    [SerializeField] private Toggle isFatherScravenger;
    [SerializeField] private Toggle isFatherGuard;
    [SerializeField] private Toggle isFatherSleep;
    [SerializeField] private Toggle isMotherScavenger;
    [SerializeField] private Toggle isMotherGuard;
    [SerializeField] private Toggle isMotherSleep;
    [SerializeField] private Toggle isSisterScavenger;
    [SerializeField] private Toggle isSisterGuard;
    [SerializeField] private Toggle isSisterSleep;
    [SerializeField] private Toggle isBrotherScavenger;
    [SerializeField] private Toggle isBrotherGuard;
    [SerializeField] private Toggle isBrotherSleep;
    [SerializeField] private Button nextMapButton;

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

    void Start()
    {
        isFatherScravenger.isOn = false;
        isFatherGuard.isOn = false;
        isFatherSleep.isOn = false;
        isMotherScavenger.isOn = false;
        isMotherGuard.isOn = false;
        isMotherSleep.isOn = false;
        isSisterScavenger.isOn = false;
        isSisterGuard.isOn = false;
        isSisterSleep.isOn = false;
        isBrotherScavenger.isOn = false;
        isBrotherGuard.isOn = false;
        isBrotherSleep.isOn = false;

        guardToggleList.Add(isFatherGuard);
        guardToggleList.Add(isBrotherGuard);
        guardToggleList.Add(isMotherGuard);
        guardToggleList.Add(isSisterGuard);
    }

    
    private void Update()
    {  
        CheclAllToggleList();
    }

      private void CheclAllToggleList()
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

    private bool CheckFatherToogleList()
    {

        if (isFatherScravenger.isOn == false && isFatherGuard.isOn == false && isFatherSleep.isOn == false)
        {
            NextMapInteraction(false);
            return false;
        }
        else
        {
            return true;
        }

    }

    private bool CheckMotherToggleList()
    {
        if (isMotherScavenger.isOn == false && isMotherGuard.isOn == false && isMotherSleep.isOn == false)
        {
            NextMapInteraction(false);
            return false;
        }
        else
        {
            return true;
        }
    }
    private bool CheckBrotherToggleList()
    {
        if (isBrotherScavenger.isOn == false && isBrotherGuard.isOn == false && isBrotherSleep.isOn == false)
        {
            NextMapInteraction(false);
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool CheckSisterToogleList()
    {
        if (isSisterScavenger.isOn == false && isSisterGuard.isOn == false && isSisterSleep.isOn == false)
        {
            NextMapInteraction(false);
            return false;
        }
        else
        {
            return true;
        }
    }

    private void NextMapInteraction(bool _enabled)
    {
        nextMapButton.interactable = _enabled;
    }

    private void CheckFatherScavenger()
    {
        if (isFatherScravenger.isOn == true)
        {
            fatherScavengerCounter = 1;
        }
        else
        {
            fatherScavengerCounter = 0;
        }
    }

    private void CheckMotherScavenger()
    {
        if (isMotherScavenger.isOn == true)
        {
            motherScavengerCounter = 1;
        }
        else
        {
            motherScavengerCounter = 0;
        }
    }

    private void CheckBrotherScavenger()
    {
        if (isBrotherScavenger.isOn == true)
        {
            brotherScavengerCounter = 1;
        }
        else
        {
            brotherScavengerCounter = 0;
        }
        
    }

    private void CheckSisterScavenger()
    {
        if (isSisterScavenger.isOn == true)
        {
            sisterScavengerCounter = 1;
        }
        else
        {
            sisterScavengerCounter = 0;
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
            // there is no scravenger here
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

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndingManageScript : MonoBehaviour
{
    [SerializeField] private CharacterStatManager father, mother, sister, brother;
    [SerializeField] private static bool isFatherDead , isMotherDead , isSisterDead , isBrotherDead;
    private static event Action OnCharacterDead;
    [SerializeField] private List<IEnding> endings = new List<IEnding>();
    [SerializeField] AllDeadEnding allDeadEnding;
    
    public static bool IsFatherDead
    {get => isFatherDead;
        set{ isFatherDead = value;
            OnCharacterDead?.Invoke();}
    }
    public static bool IsMotherDead
    {get => isMotherDead;
        set{ isMotherDead = value;
            OnCharacterDead?.Invoke();}
    }
    public static bool IsSisterDead
    {get => isSisterDead;
        set { isSisterDead = value;
            OnCharacterDead?.Invoke();}
    }
    public static bool IsBrotherDead
    {get => isBrotherDead;
        set{ isBrotherDead = value;
            OnCharacterDead?.Invoke();}
    }

    private void OnEnable() 
    {
        father.OnDead += FatherDead;
        mother.OnDead += MotherDead;
        sister.OnDead += SisterDead;
        brother.OnDead += BrotherDead;

        OnCharacterDead += CheckEnding;

        DayManagerScript.OnMaxDay += CheckEnding;
    }
    private void OnDisable() 
    {
        father.OnDead -= FatherDead;
        mother.OnDead -= MotherDead;
        sister.OnDead -= SisterDead;
        brother.OnDead -= BrotherDead;

        OnCharacterDead -= CheckEnding;

        DayManagerScript.OnMaxDay -= CheckEnding;
    }

    private void Awake() 
    {
        endings = FindObjectsOfType<MonoBehaviour>().OfType<IEnding>().ToList();
        Debug.Log($"ending count : {endings.Count}");
    }

    private void FatherDead()
    {
        IsFatherDead = true;
    }
    private void MotherDead()
    {
        IsMotherDead = true;
    }
    private void SisterDead()
    {
        IsSisterDead = true;
    }
    private void BrotherDead()
    {
        IsBrotherDead = true;
    }
    private void CheckEnding()
    {

        if( DayManagerScript.GetDays() == DayManagerScript.GetMaxDays())
        {
            foreach (var ending in endings)
            {
                ending.CheckEndingCondition();
            }
        }
        else if(IsFatherDead == true && isMotherDead == true && isSisterDead == true && isBrotherDead == true && DayManagerScript.GetDays() < DayManagerScript.GetMaxDays() == true)
        {   
            IEnding badEnding = endings.FirstOrDefault(ending => name == "AllDeadEnding");
            allDeadEnding.CheckEndingCondition();
        }
        
    }

}












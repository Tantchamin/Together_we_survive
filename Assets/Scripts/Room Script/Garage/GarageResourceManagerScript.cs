using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageResourceManagerScript : MonoBehaviour
{
    GarageResourceDisplayScript garageResourceDisplayScript;
    [SerializeField] private int woodAmount, metalAmount, tapeAmount, clotheAmount, 
     gunComponentAmount,  gunPowderAmount , herbAmount;
    public static event Action OnValueChanged;
    private int CheatStartingResource = 100000;
    void Start()
    {
        SetStartingResource();
     
    }
    private void SetStartingResource()
    {
        WoodAmount = 0; 
        MetalAmount = 0;
        TapeAmount = 0;
        ClotheAmount = 0;
        GunComponentAmount = 0;
        GunPowderAmount = 0;
        HerbAmount = 0;
    }

    public int WoodAmount
    {
        get => woodAmount; 
        set {
            OnValueChanged?.Invoke();
            woodAmount = value;
        }
    }
    public int MetalAmount
    {
        get => metalAmount;
        set {
            OnValueChanged?.Invoke();
            metalAmount = value;
        }
    }
    public int TapeAmount
    {
        get => tapeAmount;
        set{
            OnValueChanged?.Invoke();
            tapeAmount = value;
        }
    }
    public int ClotheAmount
    {
        get => clotheAmount;
        set{
            OnValueChanged?.Invoke();
            clotheAmount = value;
        }
    }
    public int GunComponentAmount
    {
        get => gunComponentAmount;
        set{
            OnValueChanged?.Invoke();
            gunComponentAmount = value;
        }
    }
    public int GunPowderAmount
    {
        get => gunPowderAmount;
        set{
            OnValueChanged?.Invoke();
            gunPowderAmount = value;
        }
    }
    public int HerbAmount
    {
        get => herbAmount;
        set{
            OnValueChanged?.Invoke();
            herbAmount = value;
        }
    }
    public void TestButton()
    {
        WoodAmount +=2;
        MetalAmount +=2;
        TapeAmount +=2;
        ClotheAmount +=2;
        GunComponentAmount +=2;
        HerbAmount +=2;
        GunPowderAmount +=2;
        MetalAmount +=2;
    }
   
}

  
    


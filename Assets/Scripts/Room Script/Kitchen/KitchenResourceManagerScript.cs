using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenResourceManagerScript : MonoBehaviour
{
    KitchenResourceDisplayScript kitchenResourceFrontendScript;
    [SerializeField] private int rawFoodAmount = 0 , rawVegetableAmount = 0, canFoodAmount = 0 , 
    medicineAmount = 0 , waterAmount = 0, bandageAmount = 0 , potatoAmount = 0 , carrotAmount  = 0 , tomatoAmount = 0 , cabbageAmount = 0 , cucumberAmount = 0;
    public event Action OnValueChanged , OnVegetableValueChanged;

    void Start() 
    {
        SetStartingResource();
        SumRawVegetable();   

    }
    private void OnEnable() 
    {
        OnVegetableValueChanged += SumRawVegetable; 
    }

    private void OnDisable() 
    {
        OnVegetableValueChanged -= SumRawVegetable; 
    }

    private void SumRawVegetable()
    {
        RawVegetableAmount = 0;
        int allVeggie =   cabbageAmount + carrotAmount + tomatoAmount + cucumberAmount + potatoAmount;
        RawVegetableAmount += allVeggie;
        OnValueChanged?.Invoke();
    }

    private void SetStartingResource()
    {
        // Maybe Change Difficulty And this will change
        RawFoodAmount = 4;
        CanFoodAmount = 0;
        MedicineAmount = 0;
        BandageAmount = 0;
        PotatoAmount = 0;
        CarrotAmount = 0;
        CabbageAmount = 0;
        TomatoAmount = 0;
    }
    
    public int RawFoodAmount
    {
        get => rawFoodAmount ; 
        set {
            rawFoodAmount = value;   
            OnValueChanged?.Invoke();
    }}
    
    public int RawVegetableAmount
    {
        get => rawVegetableAmount;
        set {
            OnValueChanged?.Invoke();
            rawVegetableAmount = value;
        }
    }
    public int CanFoodAmount
    {
        get => canFoodAmount;
        set{
            OnValueChanged?.Invoke();
            canFoodAmount = value;  
        }
    }

    public int MedicineAmount
    {
        get => medicineAmount;
        set {
            OnValueChanged?.Invoke();
            medicineAmount = value;
           
        }
    }
    public int WaterAmount
    {
        get => waterAmount;
        set{
            OnValueChanged?.Invoke();
            waterAmount = value;
            
        }
    }
    public int BandageAmount
    {
        get => bandageAmount;
        set{
            OnValueChanged?.Invoke();
            bandageAmount = value;
            
        }
    }
    public int PotatoAmount
    {
        get => potatoAmount;
        set{
            OnVegetableValueChanged?.Invoke();
            potatoAmount = value;

        }
    }
    public int CarrotAmount
    {
        get => carrotAmount;
        set{
            OnVegetableValueChanged?.Invoke();
            carrotAmount = value;
        }
    }
    public int TomatoAmount
    {
        get => tomatoAmount;
        set{
            OnVegetableValueChanged?.Invoke();
            tomatoAmount = value;
            
        }
    }
    public int CabbageAmount
    {
        get => cabbageAmount;
        set{
            OnVegetableValueChanged?.Invoke();
            cabbageAmount = value;
            
        }
    }

    public int CucumberAmount
    {
        get => cucumberAmount;
        set{
            cucumberAmount = value;
            OnVegetableValueChanged?.Invoke();
        }

    }

    public void TestValueChanged()
    {
        PotatoAmount +=2 ;
        CabbageAmount +=2;
        CarrotAmount +=2;
        TomatoAmount +=2;
        CucumberAmount +=2;
        
    }


}

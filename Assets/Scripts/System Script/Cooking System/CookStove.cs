using System;
using UnityEngine;
using UnityEngine.UI;

public class CookStove : Bonfire
{
    [SerializeField] private byte maxFuel;
    public virtual byte MaxFuel
    {
        get => maxFuel;
        private set{}
    }
    [SerializeField] private byte currentFuel;
    public virtual byte CurrentFuel 
    {
        get => currentFuel; 
        set {
            currentFuel = value;
            OnValueChanged?.Invoke();
        }
    }
    [SerializeField] public static bool isIgnited;
    public virtual bool IsIgnited
    {
        get => isIgnited;
        set => isIgnited = value;
    }
    
    [SerializeField] KitchenResourceManagerScript krms;

    public static event Action OnPutFuel , OnValueChanged;
    public static event Action<bool> OnLightedSwitch;
    [SerializeField] bool _isThisActive = false;

    [SerializeField] private Button lightStoveOnOff;

    public void OnEnable() 
    {
        FuelUI.OnFuelUse += AddFuel;
        Cooking.OnFoodCook += ReduceFuelCooking;

        CookStoveFuel.OnStoveListShow += CookStoveActive;
        CookStoveFuel.OnStoveListUnShow += CookStoveInActive;
    }
    public void OnDisable() 
    {
        FuelUI.OnFuelUse -= AddFuel;
        Cooking.OnFoodCook -= ReduceFuelCooking;

        CookStoveFuel.OnStoveListShow -= CookStoveActive;
        CookStoveFuel.OnStoveListUnShow -= CookStoveInActive;

    }  
    public override void AddFuel(Fuel fuel)
    {
        if(_isThisActive == false) return;
        if(IsIgnited == true) return;
        if(CurrentFuel == MaxFuel) return;
        if(CurrentFuel < MaxFuel)
        {
            CurrentFuel += fuel.FuelAmount;
        }
        if(CurrentFuel > MaxFuel)
        {
            CurrentFuel = MaxFuel;
        }
        OnPutFuel?.Invoke();

        HouseInventorySystem.UseItem(fuel , 1);
    }

    private void CookStoveActive()
    {
        _isThisActive = true;
    }
    private void CookStoveInActive()
    {
        _isThisActive = false;
    }

    public void ReduceFuelCooking(Food cookedFood)
    {
        CurrentFuel -= cookedFood.fuelAmount;
        if(CurrentFuel < 0)
        {
            CurrentFuel = 0;
        }
        else if(CurrentFuel > MaxFuel)
        {
            CurrentFuel = MaxFuel;
        }
        else if(currentFuel == 0)
        {
            IsIgnited = false;
        }

    }

    public bool IsFuelEnough(Food cookedFood)
    {
        if(CurrentFuel >= cookedFood.fuelAmount)
        {
            return true;
        }
        return false;
    }
    

    public override void ToggleOnOff()
    {
        IsIgnited = !IsIgnited;
        if(IsIgnited == true && CurrentFuel >= 1)
        {  
            CurrentFuel -= 1;
        }
        OnLightedSwitch?.Invoke(IsIgnited);
    }
}

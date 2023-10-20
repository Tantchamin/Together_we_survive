using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Furnace : Bonfire
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
            if(currentFuel < 0)
            {
                currentFuel = 0;
            }
            if(currentFuel >= maxFuel)
            {
                currentFuel = maxFuel;
            }
        }
    }
    [SerializeField] public static bool isIgnited;
    public virtual bool IsIgnited
    {
        get => isIgnited;
        set => isIgnited = value;
    }
    public static event Action OnPutFuel , OnValueChanged;
    public static event Action OnLightedSwitch;
    [SerializeField] private byte fuelConsumption;
    private float fuelHeat = 0.2f;
    bool _isThisActive = false;
    public float FuelHeat 
    {
        get => fuelHeat;
        set => fuelHeat = value;
    }    
    public static event Action<bool> OnFurnaceSwitch;
    private TemperatureManager temperatureManager;

    private void Awake() {
        temperatureManager = FindObjectOfType<TemperatureManager>();
    }
    private void OnEnable() 
    {
        DayManagerScript.OnDayStart += ReduceFuelDaily;
        DayManagerScript.OnDayStart += TemperatureReduceByFuel;
        
        FurnaceFuel.OnFurnaceListShow += FurnaceActive;
        FurnaceFuel.OnFurnaceListUnShow += FurnaceInActive;


        FuelUI.OnFuelUse += AddFuel;
    }
    private void OnDisable() 
    {
        DayManagerScript.OnDayStart -= ReduceFuelDaily;
        DayManagerScript.OnDayStart -= TemperatureReduceByFuel;

        FurnaceFuel.OnFurnaceListShow -= FurnaceActive;
        FurnaceFuel.OnFurnaceListUnShow -= FurnaceInActive;

        FuelUI.OnFuelUse -= AddFuel;
    }
    private void Start() 
    {
        CurrentFuel = 5;
    }

    public override void AddFuel(Fuel fuel)
    {
        if(_isThisActive == false) return;
        if(IsIgnited == true) return;
        if(HouseInventorySystem.GetItemAmount(fuel) <= 0) return;
        if(CurrentFuel == MaxFuel) return;
        if(CurrentFuel < MaxFuel)
        {
            CurrentFuel += fuel.FuelAmount;
        }
        if(CurrentFuel > MaxFuel)
        {
            CurrentFuel = MaxFuel;
        }
        

        HouseInventorySystem.UseItem(fuel , 1);
    }

    private void FurnaceActive()
    {
        _isThisActive = true;
    }
    private void FurnaceInActive()
    {
        _isThisActive = false;
    }
    private void ReduceFuelDaily()
    {
        if(IsIgnited == false) return;
        if(CurrentFuel > 0)
        {
            CurrentFuel-= fuelConsumption;
        }
        else if(CurrentFuel == 0)
        {
            IsIgnited = false;
        }
    }
    public override void ToggleOnOff()
    {
        IsIgnited = !IsIgnited;
        if(IsIgnited == true && CurrentFuel >= 1)
        {
            CurrentFuel -= 1;

        }
        OnFurnaceSwitch?.Invoke(IsIgnited);
        TemperatureReduceByFuel();
    }

    public void TemperatureReduceByFuel()
    {
        float _temperatureIncrease = CurrentFuel * FuelHeat;
        if(IsIgnited == true)
        {
            temperatureManager.Temperature += _temperatureIncrease;
        }
        else
        {
            temperatureManager.Temperature -= _temperatureIncrease;
        }
        

    }

}

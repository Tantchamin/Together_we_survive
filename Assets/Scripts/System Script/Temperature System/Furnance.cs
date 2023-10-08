using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Furnance : MonoBehaviour
{
    [SerializeField] private byte maxFuel = 10;
    public byte MaxFuel
    {
        get => maxFuel;
        set => maxFuel = value;
    }
    [SerializeField] private byte currentFuel = 0 , fuelConsumption = 2;
    public byte CurrentFuel 
    {
        get => currentFuel;
        set
        {
            currentFuel = value;
            OnValueChanged?.Invoke();
        }
    }
    private float fuelHeat = 0.2f;
    [SerializeField] private bool isFurnanceOn =false;
    public int FuelConsumption
    {
        get => fuelConsumption;
        set => fuelConsumption = (byte)value;
    }
    public float FuelHeat 
    {
        get => fuelHeat;
        set => fuelHeat = value;
    }
    private TemperatureManager temperatureManager;
    public static event Action OnPutFuel , OnValueChanged;
    private void Awake() {
        temperatureManager = FindObjectOfType<TemperatureManager>();
    }
    private void OnEnable() 
    {
        DayManagerScript.OnDayStart += ReduceFuelDaily;
        DayManagerScript.OnDayStart += TemperatureReduceByFuel;
        FuelUI.OnFuelUse += AddFuel;
    }
    private void OnDisable() 
    {
        DayManagerScript.OnDayStart -= ReduceFuelDaily;
        DayManagerScript.OnDayStart -= TemperatureReduceByFuel;
        FuelUI.OnFuelUse -= AddFuel;
    }
    private void Start() 
    {
        currentFuel = 5;
    }

    public void AddFuel(Fuel fuel)
    {
        if(HouseInventorySystem.GetItemAmount(fuel) <= 0) return;
        if(currentFuel == maxFuel) return;
        if(currentFuel < maxFuel)
        {
            CurrentFuel += fuel.FuelAmount;
        }
        if(currentFuel > maxFuel)
        {
            CurrentFuel = maxFuel;
        }
        OnPutFuel?.Invoke();

        HouseInventorySystem.UseItem(fuel , 1);
    }
    private void ReduceFuelDaily()
    {
        if(isFurnanceOn == false) return;
        if(currentFuel >= 0)
        {
            CurrentFuel-= fuelConsumption;
        }
        if(currentFuel < 0)
        {
            CurrentFuel = 0;
        }
        
    }
    public void ToggleFurnance()
    {
        isFurnanceOn = !isFurnanceOn;
        TemperatureReduceByFuel();
    }

    public void TemperatureReduceByFuel()
    {
        float _temperatureReduce = currentFuel * fuelHeat;
        if(isFurnanceOn == true)
        {
            temperatureManager.Temperature += _temperatureReduce;
        }
        else
        {
            temperatureManager.Temperature -= _temperatureReduce;
        }
        

    }


}

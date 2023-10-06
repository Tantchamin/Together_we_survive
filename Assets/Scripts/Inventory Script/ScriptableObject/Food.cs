using UnityEngine;

public class Food : Consumable
{
    [SerializeField] private byte hungerRestoreAmount;
    [SerializeField] private byte fuelAmount;
    
    [SerializeField] private byte meatAmount;
    [SerializeField] private byte potatoAmount;
    [SerializeField] private byte cucumberAmount;
    [SerializeField] private byte tomatoAmount;

    public byte HungryRestoreAmount{get => hungerRestoreAmount; private set {}}
    public byte FuelAMount {get => fuelAmount; private set {}}
}

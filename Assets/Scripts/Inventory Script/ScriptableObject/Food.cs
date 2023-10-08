using System;
using Mono.Cecil;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "SeniorProjectGame/CraftedItem/Consumable/Food", order =4)]

public class Food : Consumable
{
    [SerializeField] private byte hungerRestoreAmount;
    [SerializeField] private byte fuelAmount;
    
    [SerializeField] private byte meatAmount, potatoAmount, 
    cucumberAmount ,tomatoAmount , cabbageAmount , carrotAmount;


    public byte HungryRestoreAmount{get => hungerRestoreAmount; private set {}}
    public byte FuelAMount {get => fuelAmount; private set {}}

    
    
}

// [Serializable]
// public class ResourceData
// {
//     public string resourceName;
//     private int amount;

//     public int Amount
//     {
//         get => amount;
//         set
//         {
//             amount = value;
//         }
//     } 
// }

using System;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "SeniorProjectGame/Item/Food", order =1)]

public class Food : Item
{
    public  byte hungerRestoreAmount;
    public byte thirstyRestoreAmount;
    public  byte fuelAmount;
    
    public byte meatAmount, potatoAmount , vegetableAmount, 
    cucumberAmount ,tomatoAmount , cabbageAmount , carrotAmount , waterAmount;

    public Taste taste;
    public FoodGrade foodGrade;
    public enum Taste
    {
        Plain,
        Sour ,
        Salty,
        Sweet,
        Spicy
    }

    public enum FoodGrade
    {   
        Awful,
        Bad ,
        Good,
        Amazing,
        Highend
    }
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

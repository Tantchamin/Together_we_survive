using System;
using System.Text;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "SeniorProjectGame/Item/Food", order =1)]

public class Food : Item
{
    public  byte hungerRestoreAmount;
    public byte thirstyRestoreAmount;
    public  byte fuelAmount;
    
    public byte meatAmount, vegetableAmount, potatoAmount ,
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
    public string CookingRecipe()
    {
        StringBuilder cookingRecipe = new StringBuilder("Recipe :  \n");
        if(meatAmount > 0)
            cookingRecipe.Append($"Meat : x {meatAmount} \n");
        if(vegetableAmount > 0)
            cookingRecipe.Append($"Vegetable : x {vegetableAmount} \n");
        if(potatoAmount > 0)
            cookingRecipe.Append($"Potato : x {potatoAmount} \n");
        if(cucumberAmount > 0)
            cookingRecipe.Append($"Cucumber : x {cucumberAmount} \n");
        if(tomatoAmount > 0)
            cookingRecipe.Append($"Tomato : x {tomatoAmount} \n");
        if(cabbageAmount > 0)
            cookingRecipe.Append($"Cabbage : x {cabbageAmount}");
        if(carrotAmount > 0)
            cookingRecipe.Append($"Carrot : x {carrotAmount} \n");
        if(waterAmount > 0)
            cookingRecipe.Append($"Water : x {waterAmount} \n");
        
        return cookingRecipe.ToString();
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

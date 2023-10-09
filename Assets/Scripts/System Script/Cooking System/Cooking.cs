using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Linq;
using System.Collections.Generic;


public class Cooking : MonoBehaviour
{
    [SerializeField] private KitchenResourceManagerScript krms;
    [SerializeField] private CookStove cks;

    public static event Action<Food> OnFoodCook;
    public void Start()
    {
        krms = FindObjectOfType<KitchenResourceManagerScript>();
        cks = GetComponent<CookStove>();
    }
    public void CookFood()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        CraftUI craftUIScript =  clickedButton.GetComponentInParent<CraftUI>();

        Item item = craftUIScript.GetCraftedItem();
        var food = item as Food;
        if(cks.IsFuelEnough(food) == false) return;
        if(ReduceIngredient(food) == false) return;
        AddFood(food); 
    }

    private bool ReduceIngredient(Food cookedFood)
    {
        
        byte meat =(byte) krms.RawMeatAmount;
        byte water = (byte) krms.WaterAmount;
        byte potato = (byte) krms.PotatoAmount;
        byte cabbage = (byte) krms.CabbageAmount;
        byte carrot = (byte) krms.CarrotAmount;
        byte cucumber = (byte) krms.CucumberAmount;
        byte tomato = (byte) krms.TomatoAmount;
        byte veggies = (byte) krms.RawVegetableAmount;
        
        if(meat >= cookedFood.meatAmount && water >= cookedFood.waterAmount && potato >= cookedFood.potatoAmount
        && cabbage >= cookedFood.cabbageAmount && carrot >= cookedFood.carrotAmount && cucumber >= cookedFood.cucumberAmount
        && tomato >= cookedFood.tomatoAmount && veggies >= cookedFood.vegetableAmount)
        {
            krms.RawMeatAmount -= cookedFood.meatAmount;
            krms.WaterAmount -= cookedFood.waterAmount;
            krms.PotatoAmount -= cookedFood.potatoAmount;
            krms.CabbageAmount -= cookedFood.cabbageAmount;
            krms.CarrotAmount -= cookedFood.carrotAmount;
            krms.CucumberAmount -= cookedFood.cucumberAmount;
            krms.TomatoAmount -= cookedFood.tomatoAmount;

            byte vegetableAmount = cookedFood.vegetableAmount;
            List<byte> hasVegetableList = new List<byte>();
            

            for(byte counter = 0; counter < vegetableAmount ; counter++)
            {
                for(byte counters = 0 ; counters < krms.veggieList.Count ; counters++)
                {
                    if(krms.veggieList[counters] >= 1)
                    {
                        hasVegetableList.Add((byte) krms.veggieList[counters]);
                    }
                    byte randomVeg = (byte)UnityEngine.Random.Range(0 , hasVegetableList.Count);
                    hasVegetableList[randomVeg] -= (byte) 1;
                    Debug.Log($"The reduce vegetable {krms.veggieList[randomVeg]}");
                }           
                
            }
            OnFoodCook?.Invoke(cookedFood);
            return true;
        }

        

        return false;
    }

    private void AddFood(Food food)
    {
        Debug.Log($"Add food name : {food}");
        HouseInventorySystem.AddFoodToFoodList(food);
        HouseInventorySystem.AddItem(food , 1);
    }
}

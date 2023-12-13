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
    public static event Action OnVegetableListUpdate;
    public void CookFood()
    {
        if(cks.IsIgnited == false ) return;
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        FoodUI craftUIScript =  clickedButton.GetComponentInParent<FoodUI>();

        Item item = craftUIScript.GetFood();
        var food = item as Food;
        if(cks.IsFuelEnough(food) == false) return;
        if(ReduceIngredient(food) == false) return;
        AddFood(food); 
    }

    private bool ReduceIngredient(Food cookedFood)
    {
        int meat = krms.RawMeatAmount;
        int water = krms.WaterAmount;
        int potato =  krms.PotatoAmount;
        int cabbage = krms.CabbageAmount;
        int carrot = krms.CarrotAmount;
        int cucumber = krms.CucumberAmount;
        int tomato = krms.TomatoAmount;
        int veggies = krms.RawVegetableAmount;
        
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

            int vegetableAmount = cookedFood.vegetableAmount;
            
            
            Debug.Log($"vegetable amount : {vegetableAmount}");
            for(int counter = 0; counter < vegetableAmount ; counter++)
            {
                List<int> availableVegetables = new List<int>();
                for(int counters = 0 ; counters < krms.veggieList.Count ; counters++)
                {
                    if(krms.veggieList[counters] >= 1) // if vegetable value more than or equal to 1
                    {
                        availableVegetables.Add(counters); //  add in to this list with that index
                        /*
                        tomato 0 , potato 1 , cabbage 2, carrot 0, cucumber 3


                        abaliblevegetable index 0 =1 , index 1 = 2 , index 2 = 3;

                        */
                        // 0 1 2 3 -> 6 7 8 9
                    }                
                }
                int randomVeg = UnityEngine.Random.Range(0 , availableVegetables.Count);
                int selectIndex =  availableVegetables[randomVeg];
                Debug.Log(selectIndex);
                krms.veggieList[selectIndex] -= 1;   
                
                
            }
            OnVegetableListUpdate?.Invoke();
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

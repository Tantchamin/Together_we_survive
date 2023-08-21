using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    [SerializeField] private KitchenResourceBackendScript kitchenResourceBackendScript;
    [SerializeField] private GarageResourceBackendScript garageResourceBackendScript;

    [SerializeField] private int _rawFood = 1;
    [SerializeField] private int _wood = 1;
    [SerializeField] private int _cookedFoodAmount = 2;


    public void CookRawFood(){
        if(kitchenResourceBackendScript.GetRawFoodAmount() > 0  && garageResourceBackendScript.GetResourceFromList(0) > 0){
            kitchenResourceBackendScript.UseRawFood(_rawFood);
            Debug.Log(kitchenResourceBackendScript.GetRawFoodAmount().ToString());
            garageResourceBackendScript.UseResourceFromList(0 , _wood);
            kitchenResourceBackendScript.ReceiveCookedFood(_cookedFoodAmount);
        }
    }
}

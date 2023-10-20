using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KitchenResourceDisplayScript : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI rawFoodDisplayAmount, vegetableFoodDisplayAmount, cannedFoodDisplayAmount
    , waterDisplayAmount, tomatoDisplayAmount , potatoDisplayAmount , cabbageDisplayAmount
    , cucumberDisplayAmount , carrotDisplayAmount ;
    KitchenResourceManagerScript kitchenResourceManagerScript;

    private void Awake() 
    {
        kitchenResourceManagerScript = GetComponent<KitchenResourceManagerScript>();
    }
    private void OnEnable() {
        SwitchRoomScript.OnEnterKitchen += UpdateResourceValue;
        kitchenResourceManagerScript.OnValueChanged += UpdateResourceValue;
    }

    private void OnDisable() {
        SwitchRoomScript.OnEnterKitchen -= UpdateResourceValue;
        kitchenResourceManagerScript.OnValueChanged -= UpdateResourceValue;
    }
    
    private void UpdateResourceValue()
    {
        rawFoodDisplayAmount.text = kitchenResourceManagerScript.RawMeatAmount.ToString();
        vegetableFoodDisplayAmount.text = kitchenResourceManagerScript.RawVegetableAmount.ToString();
        cannedFoodDisplayAmount.text = kitchenResourceManagerScript.CanFoodAmount.ToString();
        waterDisplayAmount.text = kitchenResourceManagerScript.WaterAmount.ToString();
        tomatoDisplayAmount.text = kitchenResourceManagerScript.TomatoAmount.ToString();
        carrotDisplayAmount.text = kitchenResourceManagerScript.CarrotAmount.ToString();
        potatoDisplayAmount.text = kitchenResourceManagerScript.PotatoAmount.ToString();
        cabbageDisplayAmount.text = kitchenResourceManagerScript.CabbageAmount.ToString();
        cucumberDisplayAmount.text = kitchenResourceManagerScript.CucumberAmount.ToString();

    }

    
}


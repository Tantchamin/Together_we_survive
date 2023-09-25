using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatingManagementScript : MonoBehaviour
{
    [SerializeField] private CharacterStatScript CharacterStatScript;
    [SerializeField] private KitchenResourceManagerScript kitchenResourceManagerScript;
    [SerializeField] private Button _rawFoodButton, _canFoodButton, _cookedFoodButton, _waterDrinkButton, _bandageButton, _medicineButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kitchenResourceManagerScript.GetRawFoodAmount() == 0)
            _rawFoodButton.interactable = false;
        else
            _rawFoodButton.interactable = true;

        if (kitchenResourceManagerScript.GetCannedFoodAmount() == 0)
            _canFoodButton.interactable = false;
        else
            _canFoodButton.interactable = true;

        if (kitchenResourceManagerScript.GetWaterAmount() == 0)
            _waterDrinkButton.interactable = false;
        else
            _waterDrinkButton.interactable = true;

        if (kitchenResourceManagerScript.GetBandageAmount() == 0)
            _bandageButton.interactable = false;
        else
            _bandageButton.interactable = true;

        if (kitchenResourceManagerScript.GetMedicineAmount() == 0)
            _medicineButton.interactable = false;
        else
            _medicineButton.interactable = true;

        if(kitchenResourceManagerScript.GetCookedFoodAmount() == 0){
            _cookedFoodButton.interactable = false; 
        }
        else
            _cookedFoodButton.interactable = true;
        

    }

    public void RawFoodEatButton()
    {
        kitchenResourceManagerScript.UseRawFood(1);
        CharacterStatScript.CharacterHungryAdjust(+2);
        int randomNumber = Random.Range(1, 101);
        if(randomNumber  <= 50)
        {
            CharacterStatScript.CharacterFeverAdjust(-1);
        }
    }

    public void CanFoodEatButton()
    {
        kitchenResourceManagerScript.UseCannedFood(1);
        CharacterStatScript.CharacterHungryAdjust(+3);

    }

    public void CookedFoodEatButton()
    {
        kitchenResourceManagerScript.UseCookedFood(1);
        CharacterStatScript.CharacterHungryAdjust(+3);

    }

    public void WaterDrinkButton()
    {
        kitchenResourceManagerScript.UseWater(1);
        CharacterStatScript.CharacterThirstyAdjust(+3);

    }
    public void BandageUseButton()
    {
        kitchenResourceManagerScript.UseBandage(1);
        CharacterStatScript.CharacterHealthAdjust(+1);

    }
    public void MedicineUseButton()
    {
        kitchenResourceManagerScript.UseMedicine(1);
        CharacterStatScript.CharacterFeverAdjust(+5);

    }

}

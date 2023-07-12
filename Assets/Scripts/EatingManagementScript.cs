using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatingManagementScript : MonoBehaviour
{
    [SerializeField] private CharacterStatScript CharacterStatScript;
    [SerializeField] private KitchenResourceBackendScript kitchenResourceBackendScript;
    [SerializeField] private Button _rawFoodButton, _canFoodButton, _cookedFoodButton, _waterDrinkButton, _bandageButton, _medicineButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kitchenResourceBackendScript.GetRawFoodAmount() == 0)
            _rawFoodButton.interactable = false;
        else
            _rawFoodButton.interactable = true;

        if (kitchenResourceBackendScript.GetCannedFoodAmount() == 0)
            _canFoodButton.interactable = false;
        else
            _canFoodButton.interactable = true;

        if (kitchenResourceBackendScript.GetWaterAmount() == 0)
            _waterDrinkButton.interactable = false;
        else
            _waterDrinkButton.interactable = true;

        if (kitchenResourceBackendScript.GetBandageAmount() == 0)
            _bandageButton.interactable = false;
        else
            _bandageButton.interactable = true;

        if (kitchenResourceBackendScript.GetMedicineAmount() == 0)
            _medicineButton.interactable = false;
        else
            _medicineButton.interactable = true;

        _cookedFoodButton.interactable = false;

    }

    public void RawFoodEatButton()
    {
        kitchenResourceBackendScript.UseRawFood(1);
        CharacterStatScript.CharacterHungryAdjust(+2);
        int randomNumber = Random.Range(1, 101);
        if(randomNumber  <= 50)
        {
            CharacterStatScript.CharacterFeverAdjust(-1);
        }
    }

    public void CanFoodEatButton()
    {
        kitchenResourceBackendScript.UseCannedFood(1);
        CharacterStatScript.CharacterHungryAdjust(+3);

    }

    public void CookedFoodEatButton()
    {
        kitchenResourceBackendScript.UseCannedFood(1);
        CharacterStatScript.CharacterHungryAdjust(+3);

    }

    public void WaterDrinkButton()
    {
        kitchenResourceBackendScript.UseWater(1);
        CharacterStatScript.CharacterThirstyAdjust(+3);

    }
    public void BandageUseButton()
    {
        kitchenResourceBackendScript.UseBandage(1);
        CharacterStatScript.CharacterHealthAdjust(+1);

    }
    public void MedicineUseButton()
    {
        kitchenResourceBackendScript.UseMedicine(1);
        CharacterStatScript.CharacterFeverAdjust(+5);

    }

}

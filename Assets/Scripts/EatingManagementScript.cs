using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingManagementScript : MonoBehaviour
{
    [SerializeField] private CharacterStatScript CharacterStatScript;
    [SerializeField] private KitchenResourceBackendScript kitchenResourceBackendScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RawFoodEatButton()
    {
        kitchenResourceBackendScript.UseRawFood(-1);
        CharacterStatScript.CharacterHungryAdjust(+2);
        int randomNumber = Random.Range(1, 101);
        if(randomNumber  <= 50)
        {
            CharacterStatScript.CharacterFeverAdjust(-1);
        }
    }

    public void CanFoodEatButton()
    {
        kitchenResourceBackendScript.UseCannedFood(-1);
        CharacterStatScript.CharacterHungryAdjust(+3);

    }

    public void CookedFoodEatButton()
    {
        kitchenResourceBackendScript.UseCannedFood(-1);
        CharacterStatScript.CharacterHungryAdjust(+3);

    }

    public void WaterDrinkButton()
    {
        kitchenResourceBackendScript.UseWater(-1);
        CharacterStatScript.CharacterThirstyAdjust(+3);

    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class HouseCrafting : MonoBehaviour
{
    GarageResourceBackendScript garageResourceBackendScript;
    KitchenResourceBackendScript kitchenResourceBackendScript;

    public Equipment axe;
    void Start()
    {
        garageResourceBackendScript = FindObjectOfType<GarageResourceBackendScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CraftAxe(){
        int wood = garageResourceBackendScript.GetResourceFromList(0);
        int iron = garageResourceBackendScript.GetResourceFromList(1);
        if(wood >= 3 && iron >=3 ){
            HouseInventory.AddInventory(axe , 1);
            garageResourceBackendScript.UseResourceFromList(3 , 0);
            garageResourceBackendScript.UseResourceFromList(3 , 1);
            HouseInventory.PrintInventory();
        }
    }

}

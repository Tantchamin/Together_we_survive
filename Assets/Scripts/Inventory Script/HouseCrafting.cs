using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class HouseCrafting : MonoBehaviour
{
    GarageResourceBackendScript garageResourceBackendScript;
    KitchenResourceBackendScript kitchenResourceBackendScript;
    [SerializeField] private List<CraftedEquipment> CraftedEquipmentList = new List<CraftedEquipment>();

    private string craftedEquipmentName;

    [SerializeField] private CraftedEquipment axe;
    void Start()
    {
        garageResourceBackendScript = FindObjectOfType<GarageResourceBackendScript>();
        FillCraftingEquipmentList();
    }

    [ContextMenu ("FillCraftingEquipmentList")]
    void FillCraftingEquipmentList() {
        CraftedEquipmentList = Resources.LoadAll("InventoryScriptableObject" , 
        typeof(CraftedEquipment)).Cast<CraftedEquipment>().ToList();
        
    }

    public void CraftingEquipment(){
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        CraftUI craftUIScript =  clickedButton.GetComponentInParent<CraftUI>();

        CraftedEquipment equipment = craftUIScript.GetCraftedEquipment();
        if(CheckResource(equipment) == false) return;
        AddEquipment(equipment); 
    }
    

    private bool CheckResource(CraftedEquipment equipment){

        int wood = garageResourceBackendScript.GetResourceFromList(0);
        int metal = garageResourceBackendScript.GetResourceFromList(1);
        int tape = garageResourceBackendScript.GetResourceFromList(2);
        int clothe = garageResourceBackendScript.GetResourceFromList(3);
        int gunComponent = garageResourceBackendScript.GetResourceFromList(4);
        int gunPowder = garageResourceBackendScript.GetResourceFromList(5);
        int herb = garageResourceBackendScript.GetResourceFromList(6);
    
        if(wood >= equipment.woodAmount && metal >= equipment.metalAmount && tape >= equipment.tapeAmount 
        && clothe >= equipment._clotheAmount && gunPowder >= equipment._gunPowderAmount && gunComponent >= equipment._gunComponentAmount &&
        herb >= equipment._herbAmount){

            garageResourceBackendScript.UseResourceFromList(equipment.woodAmount , 0);
            garageResourceBackendScript.UseResourceFromList(equipment.metalAmount , 1);
            garageResourceBackendScript.UseResourceFromList(equipment.tapeAmount  , 2);
            garageResourceBackendScript.UseResourceFromList(equipment._clotheAmount , 3);
            garageResourceBackendScript.UseResourceFromList(equipment._gunPowderAmount , 4);
            garageResourceBackendScript.UseResourceFromList(equipment._gunComponentAmount , 5);
            garageResourceBackendScript.UseResourceFromList(equipment._herbAmount , 6);

            return true;

        }

        return false;
    }

    private void AddEquipment(CraftedEquipment equipment){
        HouseInventorySystem.AddEquipment(equipment , 1);
        
        HouseInventorySystem.PrintInventory();
        
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class HouseCrafting : MonoBehaviour
{
    GarageResourceManagerScript garageResourceManagerScript;
    KitchenResourceManagerScript KitchenResourceManagerScript;
    [SerializeField] private List<Item> CraftedEquipmentList = new List<Item>();

    private string craftedEquipmentName;
    void Start()
    {
        garageResourceManagerScript = FindObjectOfType<GarageResourceManagerScript>();
        FillCraftingEquipmentList();
    }

    [ContextMenu ("FillCraftingEquipmentList")]
    void FillCraftingEquipmentList() {
        CraftedEquipmentList = Resources.LoadAll("InventoryScriptableObject" , 
        typeof(Item)).Cast<Item>().ToList();
        
    }

    public void CraftingEquipment(){
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        CraftUI craftUIScript =  clickedButton.GetComponentInParent<CraftUI>();

        CraftedItem equipment = craftUIScript.GetCraftedEquipment();
        if(CheckResource(equipment) == false) return;
        AddEquipment(equipment); 
    }
    

    private bool CheckResource(CraftedItem equipment){

        int wood = garageResourceManagerScript.GetResourceFromList(0);
        int metal = garageResourceManagerScript.GetResourceFromList(1);
        int tape = garageResourceManagerScript.GetResourceFromList(2);
        int clothe = garageResourceManagerScript.GetResourceFromList(3);
        int gunComponent = garageResourceManagerScript.GetResourceFromList(4);
        int gunPowder = garageResourceManagerScript.GetResourceFromList(5);
        int herb = garageResourceManagerScript.GetResourceFromList(6);
    
        if(wood >= equipment.woodAmount && metal >= equipment.metalAmount && tape >= equipment.tapeAmount 
        && clothe >= equipment._clotheAmount && gunPowder >= equipment._gunPowderAmount && gunComponent >= equipment._gunComponentAmount &&
        herb >= equipment._herbAmount){

            garageResourceManagerScript.UseResourceFromList(equipment.woodAmount , 0);
            garageResourceManagerScript.UseResourceFromList(equipment.metalAmount , 1);
            garageResourceManagerScript.UseResourceFromList(equipment.tapeAmount  , 2);
            garageResourceManagerScript.UseResourceFromList(equipment._clotheAmount , 3);
            garageResourceManagerScript.UseResourceFromList(equipment._gunPowderAmount , 4);
            garageResourceManagerScript.UseResourceFromList(equipment._gunComponentAmount , 5);
            garageResourceManagerScript.UseResourceFromList(equipment._herbAmount , 6);

            return true;

        }

        return false;
    }

    private void AddEquipment(Item equipment){
        
        if(equipment.itemType == Item.ItemType.Weapon)
        {
            var equipmentAsWeapon = equipment as Weapon;
            HouseInventorySystem.AddWeaponToWeaponList(equipmentAsWeapon);
            HouseInventorySystem.AddEquipment(equipment , 1);
        }
        else if(equipment.itemType == Item.ItemType.Tool)
        {
            var equipmentAsTool = equipment as Tool;
            HouseInventorySystem.AddToolToToolList(equipmentAsTool);
            HouseInventorySystem.AddEquipment(equipment , 1);
        }
        else 
        {
            HouseInventorySystem.AddEquipment(equipment , 1);
        }
        
    }

}

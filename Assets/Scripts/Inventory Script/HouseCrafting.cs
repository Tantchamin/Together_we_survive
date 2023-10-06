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
    [SerializeField] private List<Item> CraftedItemList = new List<Item>();

    private string craftedEquipmentName;
    void Start()
    {
        garageResourceManagerScript = FindObjectOfType<GarageResourceManagerScript>();
        FillCraftingEquipmentList();
    }

    [ContextMenu ("FillCraftingEquipmentList")]
    void FillCraftingEquipmentList() {
        CraftedItemList = Resources.LoadAll("InventoryScriptableObject" , 
        typeof(Item)).Cast<Item>().ToList();
        
    }

    public void CraftingEquipment(){
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        CraftUI craftUIScript =  clickedButton.GetComponentInParent<CraftUI>();

        CraftedItem item = craftUIScript.GetCraftedEquipment();
        if(CheckResource(item) == false) return;
        AddEquipment(item); 
    }
    

    private bool CheckResource(CraftedItem item){

        int wood = garageResourceManagerScript.GetResourceFromList(0);
        int metal = garageResourceManagerScript.GetResourceFromList(1);
        int tape = garageResourceManagerScript.GetResourceFromList(2);
        int clothe = garageResourceManagerScript.GetResourceFromList(3);
        int gunComponent = garageResourceManagerScript.GetResourceFromList(4);
        int gunPowder = garageResourceManagerScript.GetResourceFromList(5);
        int herb = garageResourceManagerScript.GetResourceFromList(6);
    
        if(wood >= item.woodAmount && metal >= item.metalAmount && tape >= item.tapeAmount 
        && clothe >= item._clotheAmount && gunPowder >= item._gunPowderAmount && gunComponent >= item._gunComponentAmount &&
        herb >= item._herbAmount){

            garageResourceManagerScript.UseResourceFromList(item.woodAmount , 0);
            garageResourceManagerScript.UseResourceFromList(item.metalAmount , 1);
            garageResourceManagerScript.UseResourceFromList(item.tapeAmount  , 2);
            garageResourceManagerScript.UseResourceFromList(item._clotheAmount , 3);
            garageResourceManagerScript.UseResourceFromList(item._gunPowderAmount , 4);
            garageResourceManagerScript.UseResourceFromList(item._gunComponentAmount , 5);
            garageResourceManagerScript.UseResourceFromList(item._herbAmount , 6);

            return true;

        }

        return false;
    }

    private void AddEquipment(Item item){
        
        if(item.itemType == Item.ItemType.Weapon)
        {
            var equipmentAsWeapon = item as Weapon;
            HouseInventorySystem.AddWeaponToWeaponList(equipmentAsWeapon);
            HouseInventorySystem.AddEquipment(item , 1);
        }
        else if(item.itemType == Item.ItemType.Tool)
        {
            var equipmentAsTool = item as Tool;
            HouseInventorySystem.AddToolToToolList(equipmentAsTool);
            HouseInventorySystem.AddEquipment(item , 1);
        }
        else 
        {
            HouseInventorySystem.AddEquipment(item , 1);
        }
        
    }

}

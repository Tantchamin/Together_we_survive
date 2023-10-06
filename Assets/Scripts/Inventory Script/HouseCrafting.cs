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

        int wood = garageResourceManagerScript.WoodAmount;
        int metal = garageResourceManagerScript.MetalAmount;
        int tape = garageResourceManagerScript.TapeAmount;
        int clothe = garageResourceManagerScript.ClotheAmount;
        int gunComponent = garageResourceManagerScript.GunComponentAmount;
        int gunPowder = garageResourceManagerScript.GunPowderAmount;
        int herb = garageResourceManagerScript.HerbAmount;
    
        if(wood >= item.woodAmount && metal >= item.metalAmount && tape >= item.tapeAmount 
        && clothe >= item.clotheAmount && gunPowder >= item.gunPowderAmount && gunComponent >= item.gunComponentAmount &&
        herb >= item.herbAmount){

            garageResourceManagerScript.WoodAmount -= item.woodAmount;
            garageResourceManagerScript.MetalAmount -= item.woodAmount;
            garageResourceManagerScript.TapeAmount -= item.tapeAmount;
            garageResourceManagerScript.ClotheAmount -= item.clotheAmount;
            garageResourceManagerScript.GunComponentAmount -= item.gunComponentAmount;
            garageResourceManagerScript.GunPowderAmount -= item.gunPowderAmount;
            garageResourceManagerScript.HerbAmount -= item.herbAmount;

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

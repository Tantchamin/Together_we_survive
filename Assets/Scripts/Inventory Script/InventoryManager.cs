using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    //  private static Dictionary<CraftedEquipment , int > inventoryDictionary = new Dictionary<CraftedEquipment, int>();
    // [SerializeField] private  List<Dictionary<CraftedEquipment , int >> craftedEquipmentList 
    // = new List<Dictionary<CraftedEquipment , int >>();

    [SerializeField] private List<Item> craftedItemList = new List<Item>();
    [SerializeField] public List<Dictionary<Item , int >> houseInventoryList = new List<Dictionary<Item , int >>();
    // [SerializeField] private List<Weapon> weaponList = new List<Weapon>();
    // [SerializeField] private List<Tool> toolList = new List<Tool>();
    // [SerializeField] private List<Medicine> medicineList = new List<Medicine>();
    // [SerializeField] private List<Ammo> ammoList = new List<Ammo>();

    [SerializeField] private Transform inventoryContent;

    [SerializeField] private GameObject inventoryUI;

    private InventoryUI inventoryUIscript;

    public void ShowList(){

        FillList();
        foreach (Item item in craftedItemList){   
            if(HouseInventorySystem.GetItemAmount(item) == 0) return;    
            Debug.Log(item.itemName);
            if(IsItemInstantiated(item) == false){
                GameObject obj = Instantiate(inventoryUI , inventoryContent);
                inventoryUIscript = obj.GetComponent<InventoryUI>();
                inventoryUIscript.SetCraftedEquipment(item);    
            }
            else if((item.itemType == Item.ItemType.Weapon || item.itemType == Item.ItemType.Tool) 
            && IsItemInstantiated(item) == true){
                GameObject obj = Instantiate(inventoryUI , inventoryContent);
                inventoryUIscript = obj.GetComponent<InventoryUI>();
                inventoryUIscript.SetCraftedEquipment(item);    
            }
        }
    }
    public void ClearList(){
        foreach (Transform item in inventoryContent){
           Destroy(item.gameObject);
        }
        craftedItemList.Clear();
        
    }

    private void FillList()
    {
        houseInventoryList = HouseInventorySystem.GetItemListWithAmount();
        craftedItemList = HouseInventorySystem.GetItemListWithOutAmount();
        // weaponList = HouseInventorySystem.GetWeaponList();
        // toolList = HouseInventorySystem.GetToolsList();
        // ammoList = HouseInventorySystem.GetAmmoList();
        // medicineList = HouseInventorySystem.GetMedicineList();
    }

    private bool IsItemInstantiated(Item craftedEquipment){
        Item searchedEquipment = null;
        foreach(Transform item in inventoryContent){
            inventoryUIscript = item.gameObject.GetComponent<InventoryUI>();
            searchedEquipment = inventoryUIscript.GetCraftedEquipment();
            if(craftedEquipment == searchedEquipment){
                return true;
            }
        }
        return false;
    }

}

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

    [SerializeField] private List<Item> craftedEquipmentList = new List<Item>();
    [SerializeField] private List<Weapon> weaponList = new List<Weapon>();
    [SerializeField] private List<Tool> toolList = new List<Tool>();

    [SerializeField] private Dictionary<Item , int > houseEquipmentList = new Dictionary<Item , int>();
    [SerializeField] private Transform inventoryContent;

    [SerializeField] private GameObject inventoryUI;

    private InventoryUI inventoryUIscript;

    static public event Action OnStack;



    private void Start() {
        // Debug.Log(inventoryContent.transform.ToString());    
    }
    public void ShowList(){

        craftedEquipmentList = HouseInventorySystem.GetEquipmentListWithOutAMount();
        weaponList = HouseInventorySystem.GetWeaponList();
        toolList = HouseInventorySystem.GetToolsList();
        foreach (Item equipment in craftedEquipmentList){       
            Debug.Log(equipment.itemName);
            if(IsEquipmentInstantiated(equipment) == false){
                GameObject obj = Instantiate(inventoryUI , inventoryContent);
                inventoryUIscript = obj.GetComponent<InventoryUI>();
                inventoryUIscript.SetCraftedEquipment(equipment);    
            }
            else if((equipment.itemType == Item.ItemType.Weapon || equipment.itemType == Item.ItemType.Tool) 
            && IsEquipmentInstantiated(equipment) == true){
                GameObject obj = Instantiate(inventoryUI , inventoryContent);
                inventoryUIscript = obj.GetComponent<InventoryUI>();
                inventoryUIscript.SetCraftedEquipment(equipment);    
            }
            else if(equipment.itemType == Item.ItemType.Consumable && IsEquipmentInstantiated(equipment) == true){
                OnStack?.Invoke();
            }
        }
    }
    public void ClearList(){
        foreach (Transform item in inventoryContent){
           Destroy(item.gameObject);
        }
        craftedEquipmentList.Clear();
        
    }

    private bool IsEquipmentInstantiated(Item craftedEquipment){
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

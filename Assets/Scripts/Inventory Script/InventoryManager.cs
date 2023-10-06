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

        craftedItemList = HouseInventorySystem.GetEquipmentListWithOutAMount();
        weaponList = HouseInventorySystem.GetWeaponList();
        toolList = HouseInventorySystem.GetToolsList();
        foreach (Item item in craftedItemList){       
            Debug.Log(item.itemName);
            if(IsEquipmentInstantiated(item) == false){
                GameObject obj = Instantiate(inventoryUI , inventoryContent);
                inventoryUIscript = obj.GetComponent<InventoryUI>();
                inventoryUIscript.SetCraftedEquipment(item);    
            }
            else if((item.itemType == Item.ItemType.Weapon || item.itemType == Item.ItemType.Tool) 
            && IsEquipmentInstantiated(item) == true){
                GameObject obj = Instantiate(inventoryUI , inventoryContent);
                inventoryUIscript = obj.GetComponent<InventoryUI>();
                inventoryUIscript.SetCraftedEquipment(item);    
            }
            else if(item.itemType == Item.ItemType.Consumable && IsEquipmentInstantiated(item) == true){
                OnStack?.Invoke();
            }
        }
    }
    public void ClearList(){
        foreach (Transform item in inventoryContent){
           Destroy(item.gameObject);
        }
        craftedItemList.Clear();
        
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

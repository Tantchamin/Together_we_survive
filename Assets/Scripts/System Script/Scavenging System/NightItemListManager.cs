using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class NightItemListManager : MonoBehaviour
{
    [SerializeField] private Transform weaponContent , toolContent;
    [SerializeField] private Item currentSelectTool = null , currentSelectWeapon = null;
    [SerializeField] private GameObject spawnObj;
    [SerializeField] private List<Item> toolList;
    [SerializeField] private List<Item> weaponList;
    NightSelectItemUI nightSelectItemUI;
    public static event Action<Item> OnToolUse , OnWeaponUse;

    public void OnEnable()
    {
        DisplayList();
        NightSelectItemUI.OnWeaponSelected += DeleteItemFromList;
        NightSelectItemUI.OnToolSelected += DeleteItemFromList;
        NightSelectItemUI.OnItemSelectedBool += FillList;

        DayManagerScript.OnDayStart += RefreshList;
    }
    public void DisplayList()
    {
        FillList();
        InstantiateToolList();
        InstantiateWeaponList();
    }
    public void FillList()
    {   
        toolList = HouseInventorySystem.GetToolsList();
        weaponList = HouseInventorySystem.GetWeaponList();

        DayManagerScript.OnDayStart -= RefreshList;
    }
    
    public void RefreshList()
    {
        RefreshToolList();
        RefreshInstantiatedTool();
        RefreshInstantiatedWeapon();
        RefreshWeaponList();
        currentSelectTool = null;
        currentSelectWeapon = null;
    }

    public void RefreshToolList()
    {
        toolList.Clear();
        RefreshInstantiatedTool();
    }
    public void RefreshInstantiatedTool()
    {
        foreach(Transform item in toolContent)
        {
            Destroy(item.gameObject);
        }
    }
    public void RefreshWeaponList()
    {  
        weaponList.Clear();
        RefreshInstantiatedWeapon();
        
    }
    public void RefreshInstantiatedWeapon()
    {
        foreach(Transform item in weaponContent)
        {
            Destroy(item.gameObject);
        }
    }

    private void InstantiateToolList()
    {
        foreach(Tool tool in toolList.Cast<Tool>())
        {
            GameObject obj = Instantiate(spawnObj , toolContent);
            nightSelectItemUI = obj.GetComponent<NightSelectItemUI>();
            nightSelectItemUI.SetItem(tool as Item);

        }
    }
    private void InstantiateWeaponList()
    {
        foreach(Weapon weapon in weaponList.Cast<Weapon>())
        {
            GameObject obj = Instantiate(spawnObj , weaponContent);
            nightSelectItemUI = obj.GetComponent<NightSelectItemUI>();
            nightSelectItemUI.SetItem(weapon as Item);

        }
    }
    private void DeleteItemFromList(Item item)
    {
        if(item.itemType == Item.ItemType.Weapon)
        {
            RefreshInstantiatedWeapon();
            if(currentSelectWeapon!= null)
            {
                AddCurrentSelectItemToList(item);
            }
            Weapon weapon = item as Weapon;
            weaponList.Remove(weapon);
            currentSelectWeapon = weapon;
            InstantiateWeaponList();
        }
        else if(item.itemType == Item.ItemType.Tool)
        {
            RefreshInstantiatedTool();
            if(currentSelectTool!= null)
            {
                AddCurrentSelectItemToList(item);
            }
            Tool tool = item as Tool;
            toolList.Remove(tool);
            currentSelectTool = tool;
            InstantiateToolList();
        }
    }

    private void AddCurrentSelectItemToList(Item item)
    {
        if(item as Weapon == true)
        {
            weaponList.Add(currentSelectWeapon);
        }
        else if(item as Tool == true)
        {
            toolList.Add(currentSelectTool);
        }
    }

    public void OnLeaving()
    {
        OnToolUse?.Invoke(currentSelectTool);
        OnWeaponUse?.Invoke(currentSelectWeapon);
    }
}

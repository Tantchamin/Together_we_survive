using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System;

public class NightSelectItemUI : MonoBehaviour
{
    [SerializeField] private Item selectItem;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image itemSprite;

    public static event Action<Item> OnWeaponSelected , OnToolSelected;
    public static event Action OnItemSelectedBool;

    public void SetItem(Item item)
    {
        selectItem = item;
        itemSprite.sprite = item.itemIcon;
        itemName.text = item.itemName;
    }


    public void SelectItem()
    {
        if(selectItem.itemType == Item.ItemType.Weapon)
        {   
            OnWeaponSelected?.Invoke(selectItem);
        }
        else if(selectItem.itemType == Item.ItemType.Tool)
        {
            OnToolSelected?.Invoke(selectItem);
        }
        
    }
}

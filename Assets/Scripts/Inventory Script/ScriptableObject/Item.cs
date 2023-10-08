using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Equipment", menuName = "SeniorProjectGame/Item", order = 0)]
public abstract class Item : ScriptableObject 
{
    public string itemName; 
    public int ID; 

    [TextArea (4,4)]
    public string description;
    public Sprite itemIcon;
    public ItemType  itemType;
    public  enum ItemType{
        Fuel,
        Weapon ,
        Tool,
        Medicine,
        Ammo
    }
}

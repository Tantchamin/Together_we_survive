using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Equipment", menuName = "SeniorProjectGame/Equipment", order = 0)]
public abstract class Equipment : ScriptableObject 
{

    public string equipmentName; 
    public int ID; 

    [TextArea (4,4)]
    public string description;
    public Sprite equipmentIcon;
    public ItemType  itemType;
    public  enum ItemType{
        Consumable ,
        Weapon ,
        Tool,
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "SeniorProjectGame/CraftedItem/Tool", order = 0)]
public class Tool : CraftedItem
{
    public int strengthRequired;
    public int durability;
    public enum ToolType
    {
        craftmanship ,
        argiculture , 
        rucksack ,
        utilities
    }
    public ToolType toolType;
    

}

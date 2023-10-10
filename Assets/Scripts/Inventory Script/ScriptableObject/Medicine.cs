using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SeniorProjectGame/CraftedItem/Consumable/Medicine", order =2)]

public class Medicine : Consumable
{
    public byte healAmount;
    public byte healthyAmount;
    public byte infectedAmount; 
    public bool isCureInfected;

}

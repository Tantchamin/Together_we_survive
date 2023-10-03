using UnityEngine;
[CreateAssetMenu(fileName = "Equipment", menuName = "SeniorProjectGame/Equipment/Weapon", order = 1)]

public class Weapon : CraftedEquipment
{
    public int strengthRequired;
    public int durability;
    public int damage;
}

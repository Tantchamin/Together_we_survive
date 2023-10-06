using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "SeniorProjectGame/CraftedItem/Consumable/Fuel", order =2)]
public class Fuel : Consumable
{
    [SerializeField] private byte fuelAmount;

    public byte FuelAmount {get => fuelAmount; private set{}}
}

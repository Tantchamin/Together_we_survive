using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SeniorProjectGame/CraftedItem/Consumable/Medicine", order =2)]

public class Medicine : Consumable
{
    [SerializeField] private byte healAmount;
    [SerializeField] private byte infectedAmount;
    [SerializeField] private bool isCureInfected;


    public byte HealAmount{get => healAmount; private set{}}
    public byte InfectedAmount{get => infectedAmount; private set{}}
    public bool IsCureInfected{get => isCureInfected; private set{}}
}

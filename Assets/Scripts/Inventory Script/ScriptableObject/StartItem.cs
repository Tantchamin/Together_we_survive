using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StartingItem", menuName = "SeniorProjectGame/StartingItem", order = 0)]
public class StartItem : ScriptableObject
{
    public List<Item> startingItemList = new List<Item>();
}

using UnityEngine;
[CreateAssetMenu (fileName = "HouseUpgrade", menuName = "SeniorProjectGame/HouseLevel", order = 0) ]
public class HouseUpgradeMaterial : ScriptableObject
{
    [SerializeField] private int woodAmount;
    [SerializeField] private int metalAmount;
    [SerializeField] private int tapeAmount;

    [SerializeField] private byte upgradeDays;
    public int WoodAmount{get {return woodAmount;} private set{}}
    public int MetalAmount{get{return metalAmount;} private set{}}
    public int TapeAmount{get {return tapeAmount;} private set{}}
    public byte UpgradeDays{get {return upgradeDays;} private set{}}
    
        
    
}

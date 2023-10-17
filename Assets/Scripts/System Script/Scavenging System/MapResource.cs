using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapResource : MonoBehaviour
{
    [SerializeField] private GarageResourceManagerScript grms;
    [SerializeField] private KitchenResourceManagerScript krms;
    [SerializeField] private SResourceCharacter sResourceCharacter;

    [SerializeField] private Item bandage , antibiotics , kitchenKnife , crowbar ,
    hammer , wrench , fireAxe , ammo , roastPotato , fuelWood , fuelClothe;

    [SerializeField] private byte rawMeatAmount , canFoodAmount , waterAmount , potatoAmount , carrotAmount , tomatoAmount
    , cabbageAmount , cucumberAmount , woodAmount , metalAmount , tapeAmount , clotheAmount , gunComponentAmount
    , gunPowderAmount , herbAmount;

    private byte maxItemDaily = 10;

    [SerializeField] private List<Item> scravengerItemList = new List<Item>();
    private Dictionary<Item , byte> scravengerItemDic = new Dictionary<Item, byte>();
    //private Dictionary<string , byte> ResourceList = new Dictionary<string, byte>();
    [SerializeField] private List<ResourceData>  resourceList = new List<ResourceData>();
    public static event Action<List<ResourceData> , Dictionary<Item , byte>> OnResourceReport;
    private void OnEnable() 
    {
        MapSelectScript.OnVillageToggle += VillageResource;
        MapSelectScript.OnMarketToggle += MarketResource;
        MapSelectScript.OnHospitalToggle += HospitalResource;
        MapSelectScript.OnGasStationToggle += GasStationResource;
    }

    private void OnDisable() 
    {
        MapSelectScript.OnVillageToggle -= VillageResource;
        MapSelectScript.OnMarketToggle -= MarketResource;
        MapSelectScript.OnHospitalToggle -= HospitalResource;
        MapSelectScript.OnGasStationToggle -= GasStationResource;
    }

    private void Start() 
    {
        grms = FindObjectOfType<GarageResourceManagerScript>();
        krms = FindObjectOfType<KitchenResourceManagerScript>();
        FillResourceList();

    }

    private void FillResourceList()
    {
        resourceList.Add(new ResourceData("woodAmount" , 0));
        resourceList.Add(new ResourceData("metalAmount", 0));
        resourceList.Add(new ResourceData("tapeAmount" , 0));
        resourceList.Add(new ResourceData("clotheAmount" , 0));
        resourceList.Add(new ResourceData("gunComponentAmount" , 0));
        resourceList.Add(new ResourceData("gunPowderAmount" , 0));
        resourceList.Add(new ResourceData("herbAmount" , 0));
        
        resourceList.Add(new ResourceData("rawMeatAmount" , 0));
        resourceList.Add(new ResourceData("canFoodAmount" ,0));
        resourceList.Add(new ResourceData("waterAmount" , 0));
        resourceList.Add(new ResourceData("potatoAmount" ,0));
        resourceList.Add(new ResourceData("cabbageAmount",0));
        resourceList.Add(new ResourceData("carrotAmount" ,0));
        resourceList.Add(new ResourceData("tomatoAmount",0));
        resourceList.Add(new ResourceData("cucumberAmount" , 0));
    }
    private void SetResourceValue()
    {
        var woodResource = resourceList.FirstOrDefault(r => r.resourceName == "woodAmount");
        woodResource.resourceAmount = woodAmount;
        var metalResource = resourceList.FirstOrDefault(r => r.resourceName == "metalAmount");
        metalResource.resourceAmount = metalAmount;
        var tapeResource = resourceList.FirstOrDefault(r => r.resourceName == "tapeAmount");
        tapeResource.resourceAmount = tapeAmount;
        var cloteResource = resourceList.FirstOrDefault(r => r.resourceName == "clotheAmount");
        cloteResource.resourceAmount = clotheAmount;
        var gunComponentResource = resourceList.FirstOrDefault(r => r.resourceName == "gunComponentAmount");
        gunComponentResource.resourceAmount = gunComponentAmount;
        var gunPowderResource = resourceList.FirstOrDefault(r => r.resourceName == "gunPowderAmount");
        gunPowderResource.resourceAmount = gunPowderAmount;
        var herbResource = resourceList.FirstOrDefault (r => r.resourceName == "herbAmount");
        herbResource.resourceAmount = herbAmount;

        var rawFoodResource = resourceList.FirstOrDefault( r=> r.resourceName == "rawMeatAmount");
        rawFoodResource.resourceAmount = rawMeatAmount;
        var canFoodResource = resourceList.FirstOrDefault( r=> r.resourceName == "canFoodAmount");
        canFoodResource.resourceAmount = canFoodAmount;
        var waterResource = resourceList.FirstOrDefault(r => r.resourceName == "waterAmount");
        waterResource.resourceAmount = waterAmount;
        var potatoResource = resourceList.FirstOrDefault(r=> r.resourceName == "potatoAmount");
        potatoResource.resourceAmount = potatoAmount;
        var cabbageResource = resourceList.FirstOrDefault(r=> r.resourceName == "cabbageAmount");
        cabbageResource.resourceAmount = cabbageAmount;
        var carrotResource = resourceList.FirstOrDefault(r=> r.resourceName == "carrotAmount");
        carrotResource.resourceAmount = carrotAmount;
        var tomatoResource = resourceList.FirstOrDefault(r=> r.resourceName == "tomatoAmount");
        tomatoResource.resourceAmount = tomatoAmount;
        var cucumberResource = resourceList.FirstOrDefault(r=> r.resourceName == "cucumberAmount");
        cucumberResource.resourceAmount = cucumberAmount;

    }

    private void ResetDaily()
    {
        maxItemDaily = sResourceCharacter.GetItemCarryAmount();
        scravengerItemList.Clear();
        scravengerItemDic.Clear();
        ClearResourceAmount();
    }

    private void ClearResourceAmount()
    {
        FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo field in fields)
        {
            if (field.GetCustomAttribute(typeof(SerializeField)) != null)
            {
                if (field.FieldType == typeof(byte))
                {
                    field.SetValue(this, (byte)0);
                }
            }
        }
    }

    public void CheckItemKey(Item key , byte value)
    {
        if(scravengerItemDic.ContainsKey(key) == true)
        {
            scravengerItemDic[key] += value;
        }
        else
        {
            scravengerItemDic.Add(key , value);
        }
    }

    public void InvokeList()
    {   
        OnResourceReport(resourceList , scravengerItemDic);
    }

    private void VillageResource()
    {
        ResetDaily();
        for(byte resourceCount = 0 ; resourceCount < maxItemDaily ; resourceCount++)
        {
            byte ramdomNumMaxTwo = (byte) Random.Range(1,2);
            byte ramdomNumMaxThree = (byte) Random.Range(1,3);
            byte randomNumber = (byte) Random.Range(1,100);
            switch(randomNumber) 
            {
                case <= 13 : 
                    grms.WoodAmount += ramdomNumMaxThree;
                    woodAmount += ramdomNumMaxThree;
                    break;
                case <= 26 : 
                    grms.MetalAmount += ramdomNumMaxThree;
                    metalAmount += ramdomNumMaxThree;
                    break;
                case <= 39 :
                    grms.TapeAmount +=  ramdomNumMaxThree;
                    tapeAmount += ramdomNumMaxThree;
                    break;
                case <= 52 :
                    grms.ClotheAmount +=  ramdomNumMaxThree;
                    clotheAmount += ramdomNumMaxThree;
                    break;
                case <= 65 : 
                    grms.WoodAmount +=  ramdomNumMaxTwo;
                    woodAmount += ramdomNumMaxTwo;
                    break;
                case <= 78 :
                    grms.MetalAmount +=  ramdomNumMaxTwo;
                    metalAmount += ramdomNumMaxTwo;
                    break;
                case <= 85 :
                    grms.GunComponentAmount +=  ramdomNumMaxThree;
                    gunComponentAmount += ramdomNumMaxThree;
                    break;
                case <= 92 :
                    grms.GunPowderAmount += ramdomNumMaxThree;
                    gunPowderAmount += ramdomNumMaxThree;
                    break;
                case <= 94 :
                    HouseInventorySystem.AddItem(crowbar ,1 );
                    CheckItemKey(crowbar , 1);
                    scravengerItemList.Add(crowbar);
                    break;
                case <= 96 :
                    HouseInventorySystem.AddItem(hammer , 1);
                    CheckItemKey(hammer, 1);
                    scravengerItemList.Add(hammer);
                    break;
                case <= 99 :
                    HouseInventorySystem.AddItem(wrench , 1);
                    CheckItemKey(wrench , 1);
                    scravengerItemList.Add(wrench);
                    break;
                case  100 : 
                    HouseInventorySystem.AddItem(kitchenKnife , 1);
                    CheckItemKey(kitchenKnife , 1);
                    scravengerItemList.Add(kitchenKnife);
                    break;
            }
        }
        SetResourceValue();
        InvokeList();
    }

    private void MarketResource()
    {
        ResetDaily();
        for(byte resourceCount = 0 ; resourceCount < maxItemDaily ; resourceCount++)
        {
            byte ramdomNumMaxTwo = (byte) Random.Range(1,2);
            byte ramdomNumMaxThree = (byte) Random.Range(1,3);
            byte randomNumber = (byte) Random.Range(1,100);
            switch(randomNumber)
            {
                case <= 13: 
                    krms.RawMeatAmount += ramdomNumMaxThree;
                    rawMeatAmount += ramdomNumMaxThree;
                    break;
                case <= 26:
                    krms.PotatoAmount += ramdomNumMaxThree;
                    potatoAmount += ramdomNumMaxThree;
                    break;
                case <=  39:
                    krms.WaterAmount += ramdomNumMaxThree;
                    waterAmount += ramdomNumMaxThree;
                    break;
                case <= 52 :
                    krms.TomatoAmount += ramdomNumMaxThree;
                    tomatoAmount += ramdomNumMaxThree;
                    break;
                case <= 65 :
                    krms.CanFoodAmount += ramdomNumMaxTwo;
                    canFoodAmount += ramdomNumMaxTwo;
                    break;
                case <= 78 :
                    krms.CarrotAmount += ramdomNumMaxThree;
                    carrotAmount += ramdomNumMaxThree;
                    break;
                case <= 91 :
                    krms.CabbageAmount += ramdomNumMaxThree;
                    cabbageAmount += ramdomNumMaxThree;
                    break;
                case <= 99 :
                    krms.CucumberAmount += ramdomNumMaxThree;
                    cucumberAmount += ramdomNumMaxThree;
                    break;
                case 100 :
                    HouseInventorySystem.AddItem(antibiotics , 1);
                    CheckItemKey(antibiotics , 1);
                    scravengerItemList.Add(antibiotics);
                    break;
            }
            
        }
        SetResourceValue();
        InvokeList();
    }
    private void HospitalResource()
    {
        ResetDaily();
        for(byte resourceCount = 0 ; resourceCount < maxItemDaily ; resourceCount++)
        {
            byte ramdomNumMaxThree = (byte) Random.Range(1,3);
            byte randomNumber = (byte) Random.Range(1,100);
            switch(randomNumber) 
            {
                case <= 10 :
                    break;
                case <= 20 :
                    grms.HerbAmount += ramdomNumMaxThree;
                    herbAmount += ramdomNumMaxThree;
                    break;
                case <= 30 :
                    break;
                case <= 40 :
                    krms.CanFoodAmount += ramdomNumMaxThree;
                    canFoodAmount += ramdomNumMaxThree;
                    break;
                case <= 50 :
                    krms.WaterAmount += ramdomNumMaxThree;
                    waterAmount += ramdomNumMaxThree;
                    break;
                case <= 60 :
                    break;
                case <= 70 :
                    HouseInventorySystem.AddItem(bandage ,1);
                    CheckItemKey(bandage , 1);
                    scravengerItemList.Add(bandage);
                    break;
                case <= 80 :
                    HouseInventorySystem.AddItem(bandage,2);
                    CheckItemKey(bandage , 2);
                    scravengerItemList.Add(bandage);
                    scravengerItemList.Add(bandage);
                    break;
                case <= 90 :
                    break;
                case <= 99 :
                    HouseInventorySystem.AddItem(antibiotics , 1);
                    CheckItemKey(antibiotics , 1);
                    scravengerItemList.Add(antibiotics);
                    break;
                case <= 100 :
                    HouseInventorySystem.AddItem(antibiotics , 2);
                    CheckItemKey(antibiotics , 2);
                    scravengerItemList.Add(antibiotics);
                    scravengerItemList.Add(antibiotics);
                    break;
            }
        }
        SetResourceValue();
        InvokeList();
    }
    private void GasStationResource()
    {
        ResetDaily();
        for(byte resourceCount = 0 ; resourceCount < maxItemDaily ; resourceCount++)
        {
            byte ramdomNumMaxThree = (byte) Random.Range(1,3);
            byte randomNumber = (byte) Random.Range(1,100);
            switch (randomNumber) 
            {
                case <= 10 : 
                    HouseInventorySystem.AddItem(fuelWood , 1);
                    CheckItemKey(fuelWood , 1);
                    scravengerItemList.Add(fuelWood);
                    break;
                case <= 20 :
                    grms.WoodAmount += ramdomNumMaxThree;
                    woodAmount += ramdomNumMaxThree;
                    break;
                case <= 30 :
                    grms.ClotheAmount += ramdomNumMaxThree;
                    clotheAmount += ramdomNumMaxThree;
                    break;
                case <= 40 : 
                    HouseInventorySystem.AddItem(fuelWood , 1);
                    CheckItemKey(fuelWood , 1);
                    scravengerItemList.Add(fuelWood);
                    break;
                case <= 50 :
                    HouseInventorySystem.AddItem(fuelClothe , 1);
                    CheckItemKey(fuelClothe , 1);
                    scravengerItemList.Add(fuelClothe);
                    break;
                case <= 60 :
                    HouseInventorySystem.AddItem(fuelClothe , 2);
                    CheckItemKey(fuelClothe , 2);
                    scravengerItemList.Add(fuelClothe);
                    scravengerItemList.Add(fuelClothe);
                    break;
                case <= 70 :
                    HouseInventorySystem.AddItem(fuelWood , 2);
                    CheckItemKey(fuelWood , 2);
                    scravengerItemList.Add(fuelWood);
                    scravengerItemList.Add(fuelWood);
                    break;
                case <= 80 : 
                    grms.MetalAmount += ramdomNumMaxThree;
                    metalAmount += ramdomNumMaxThree;
                    break;
                case <= 85 :
                    grms.GunComponentAmount += ramdomNumMaxThree;
                    gunComponentAmount += ramdomNumMaxThree;
                    break;
                case <= 90 :
                    grms.GunPowderAmount += ramdomNumMaxThree;
                    gunPowderAmount += ramdomNumMaxThree;
                    break;
                case <= 95 :
                    HouseInventorySystem.AddItem(fireAxe , 1);
                    CheckItemKey(fireAxe , 1);
                    scravengerItemList.Add(fireAxe);
                    break;
                case <= 99 :
                    HouseInventorySystem.AddItem(roastPotato , 2);
                    CheckItemKey(roastPotato , 2);
                    scravengerItemList.Add(roastPotato);
                    scravengerItemList.Add(roastPotato);
                    break;
                case 100 :
                    HouseInventorySystem.AddItem(ammo , 1);
                    CheckItemKey(ammo , 1);
                    scravengerItemList.Add(ammo);
                    break;

            }
        }
        SetResourceValue();
        InvokeList();
    }
}



public class ResourceData
{
    public string resourceName{get; set;}
    public byte resourceAmount{get; set;}

    public ResourceData(string resourceName , byte resourceAmount)
    {
        this.resourceName = resourceName;
        this.resourceAmount = resourceAmount;
    }

    

}

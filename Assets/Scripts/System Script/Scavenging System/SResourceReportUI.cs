using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SResourceReportUI : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectPanel;
    [SerializeField] private GameObject spawnItemObj , spawnResourceObj;
    [SerializeField] private Transform spawnItemContent , spawnResourceContent;

    [SerializeField] private Sprite wood , metal , tape , clothe , gunComponent , gunPowder , herb 
    , rawMeat , canFood , water , potato , cabbage , carrot , tomato , cucumber;
    NightItemUI nightItemUI;
    SResourceUI nightResourceUI;

    private void OnEnable() {
        MapResource.OnResourceReport += ResourceReport;
    }

    private void OnDisable() {
        MapResource.OnResourceReport -= ResourceReport;
    } 

    private void ResourceReport(List<ResourceData> resourceListData , Dictionary<Item , byte> scravengedItem)
    {
        gameObjectPanel.SetActive(true);
        ClearContent();
        DisplayResource(resourceListData);
        DisplayItem(scravengedItem);
    }

    private void DisplayResource(List<ResourceData> resourceListData)
    {
        foreach(ResourceData resourceData in resourceListData)
        {
            if(resourceData.resourceAmount <= 0) continue;
            GameObject obj = Instantiate(spawnResourceObj , spawnResourceContent);
            nightResourceUI = obj.GetComponent<SResourceUI>();
            switch(resourceData.resourceName)
            {
                case "woodAmount" : 
                    nightResourceUI.SetItem(wood , resourceData.resourceAmount);
                    break;
                case "metalAmount" : 
                    nightResourceUI.SetItem(metal , resourceData.resourceAmount);
                    break;
                case "tapeAmount" : 
                    nightResourceUI.SetItem(tape , resourceData.resourceAmount);
                    break;
                case "clotheAmount" : 
                    nightResourceUI.SetItem(clothe , resourceData.resourceAmount);
                    break;
                case "gunComponentAmount" : 
                    nightResourceUI.SetItem(gunComponent , resourceData.resourceAmount);
                    break;
                case "gunPowderAmount" : 
                    nightResourceUI.SetItem(gunPowder , resourceData.resourceAmount);
                    break;
                case "herbAmount" : 
                    nightResourceUI.SetItem(herb , resourceData.resourceAmount);
                    break;
                case "rawMeatAmount" : 
                    nightResourceUI.SetItem(rawMeat , resourceData.resourceAmount);
                    break;
                case "canFoodAmount" : 
                    nightResourceUI.SetItem(canFood , resourceData.resourceAmount);
                    break;
                case "waterAmount" : 
                    nightResourceUI.SetItem(water , resourceData.resourceAmount);
                    break;
                case "potatoAmount" : 
                    nightResourceUI.SetItem(potato , resourceData.resourceAmount);
                    break;
                case "cabbageAmount" : 
                    nightResourceUI.SetItem(cabbage , resourceData.resourceAmount);
                    break;
                case "carrotAmount" : 
                    nightResourceUI.SetItem(carrot , resourceData.resourceAmount);
                    break;
                case "tomatoAmount" : 
                    nightResourceUI.SetItem(tomato , resourceData.resourceAmount);
                    break;
                case "cucumberAmount" : 
                    nightResourceUI.SetItem(cucumber , resourceData.resourceAmount);
                    break;
            }
        }
    }

    private void DisplayItem(Dictionary<Item , byte> itemDic)
    {
        foreach (KeyValuePair<Item,byte> kvp in itemDic)
        {
            GameObject obj = Instantiate(spawnItemObj , spawnItemContent);          
            nightItemUI = obj.GetComponent<NightItemUI>();
            nightItemUI.SetItem(kvp.Key , kvp.Value);
            
        }
    }

    public void ClearContent()
    {
        foreach(Transform item in spawnResourceContent)
        {
            Destroy(item.gameObject);
        }

        foreach(Transform item in spawnItemContent)
        {
            Destroy(item.gameObject);
        }
    }

    private bool CheckIfItemIsInstantiated(Item checkItem)
    {
        foreach(Transform item in spawnItemContent)
        {
            nightItemUI = item.GetComponent<NightItemUI>();
            Item thisItem = nightItemUI.GetItem();

            if(thisItem == checkItem)
            {
                return true;
            }
        }
        return false;

    }




}

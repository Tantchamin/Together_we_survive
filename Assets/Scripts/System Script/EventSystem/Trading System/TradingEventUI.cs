using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class TradingEventUI : MonoBehaviour
{
    [SerializeField] private TradingEvent tradingEvent;
    [SerializeField] private GameObject gameObjectPanel;
    [SerializeField] private GameObject spawnResources;
    [SerializeField] private Transform wantResourceContent , receiveResourceContent;
    [SerializeField] private TextMeshProUGUI tradeTittle , acceptText , declineText;
    [SerializeField] private Sprite wood , metal , tape , clothe , guncomponent , gunpowder , herb;
    [SerializeField] private Sprite canfood , meat , water , carrot , potato , tomato , cucumber , cabbage;
    [SerializeField] private Button acceptButton;
    SResourceUI tradeResourceUI;


    private void OnEnable() 
    {
        RandomEventChance.OnTradingEvent += OnTraderArrive;

        TradingResourceManager.OnResourceLack += DisableButtonUI;
        TradingResourceManager.OnTradeFinish += TradePanelUI;
    }
    private void OnDisable() 
    {
        RandomEventChance.OnTradingEvent -= OnTraderArrive;

        TradingResourceManager.OnResourceLack -= DisableButtonUI;
        TradingResourceManager.OnTradeFinish -= TradePanelUI;
    }

    private void OnTraderArrive(RandomEvent randomEvent)
    {
        TradingEvent tradingEvent = randomEvent as TradingEvent;
        this.tradingEvent = tradingEvent;
        TradePanelUI();
        ClearContent();
        DisplayWantResource(tradingEvent);
        DisplayReceiveResource(tradingEvent);


    }
     private void DisplayWantResource(TradingEvent tradingEvent)
    {
        foreach(TradingEvent.GameResources gameResources in tradingEvent.wantResources.resourceList)
        {
            GameObject obj = Instantiate(spawnResources , wantResourceContent);
            tradeResourceUI = obj.GetComponent<SResourceUI>();
            switch(gameResources.resourcesName)
            {
                case "wood":
                    tradeResourceUI.SetItem(wood, gameResources.resourcesAmount);
                    break;
                case "metal":
                    tradeResourceUI.SetItem(metal, gameResources.resourcesAmount);
                    break;
                case "tape":
                    tradeResourceUI.SetItem(tape, gameResources.resourcesAmount);
                    break;
                case "clothe":
                    tradeResourceUI.SetItem(clothe, gameResources.resourcesAmount);
                    break;
                case "guncomponent":
                    tradeResourceUI.SetItem(guncomponent, gameResources.resourcesAmount);
                    break;
                case "gunpowder":
                    tradeResourceUI.SetItem(gunpowder, gameResources.resourcesAmount);
                    break;
                case "herb":
                    tradeResourceUI.SetItem(herb, gameResources.resourcesAmount);
                    break;
                // FOOD 
                
                
                case "meat":
                    tradeResourceUI.SetItem(meat, gameResources.resourcesAmount);
                    break;
                case "canfood":
                    tradeResourceUI.SetItem(canfood, gameResources.resourcesAmount);
                    break;
                case "water":
                    tradeResourceUI.SetItem(water, gameResources.resourcesAmount);
                    break;
                case "cucumber":
                    tradeResourceUI.SetItem(cucumber, gameResources.resourcesAmount);
                    break;
                case "cabbage":
                    tradeResourceUI.SetItem(cabbage, gameResources.resourcesAmount);
                    break;
                case "tomato":
                    tradeResourceUI.SetItem(tomato, gameResources.resourcesAmount);
                    break;
                case "potato":
                    tradeResourceUI.SetItem(potato, gameResources.resourcesAmount);
                    break;
                case "carrot":
                    tradeResourceUI.SetItem(carrot, gameResources.resourcesAmount);
                    break;


                
            }
        }
    }

    private void DisplayReceiveResource(TradingEvent tradingEvent)
    {
        foreach(TradingEvent.GameResources gameResources in tradingEvent.receiveResources.resourceList)
        {
            GameObject obj = Instantiate(spawnResources , receiveResourceContent);
            tradeResourceUI = obj.GetComponent<SResourceUI>();
            switch(gameResources.resourcesName)
            {
                case  "wood":
                    tradeResourceUI.SetItem(wood, gameResources.resourcesAmount);
                    break;
                case "metal":
                    tradeResourceUI.SetItem(metal, gameResources.resourcesAmount);
                    break;
                case "tape":
                    tradeResourceUI.SetItem(tape, gameResources.resourcesAmount);
                    break;
                case "clothe":
                    tradeResourceUI.SetItem(clothe, gameResources.resourcesAmount);
                    break;
                case "guncomponent":
                    tradeResourceUI.SetItem(guncomponent, gameResources.resourcesAmount);
                    break;
                case "gunpowder":
                    tradeResourceUI.SetItem(gunpowder, gameResources.resourcesAmount);
                    break;
                case "herb":
                    tradeResourceUI.SetItem(herb, gameResources.resourcesAmount);
                    break;

                
                case "meat":
                    tradeResourceUI.SetItem(meat, gameResources.resourcesAmount);
                    break;
                case "canfood":
                    tradeResourceUI.SetItem(canfood, gameResources.resourcesAmount);
                    break;
                case "water":
                    tradeResourceUI.SetItem(water, gameResources.resourcesAmount);
                    break;
                case "cucumber":
                    tradeResourceUI.SetItem(cucumber, gameResources.resourcesAmount);
                    break;
                case "cabbage":
                    tradeResourceUI.SetItem(cabbage, gameResources.resourcesAmount);
                    break;
                case "tomato":
                    tradeResourceUI.SetItem(tomato, gameResources.resourcesAmount);
                    break;
                case "potato":
                    tradeResourceUI.SetItem(potato, gameResources.resourcesAmount);
                    break;
                case "carrot":
                    tradeResourceUI.SetItem(carrot, gameResources.resourcesAmount);
                    break;

            }
        }
    }

   

    private void ClearContent()
    {
        foreach(Transform item in wantResourceContent)
        {
            Destroy(item.gameObject);
        }

        foreach(Transform item in receiveResourceContent)
        {
            Destroy(item.gameObject);
        }
    }

    private void TradePanelUI()
    {
        SetButtonUI();
        gameObjectPanel.SetActive(!gameObjectPanel.activeSelf);
    }

    private void SetButtonUI()
    {
        tradeTittle.text = tradingEvent.eventName.ToString();
        acceptText.text = tradingEvent.acceptDecision.ToString();
        declineText.text = tradingEvent.declineDecision.ToString();
    }

    private void DisableButtonUI()
    {
        acceptButton.interactable = false;
    }
}

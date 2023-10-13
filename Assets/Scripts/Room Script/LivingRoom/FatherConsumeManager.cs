using System;
using UnityEngine;

public class FatherConsumeManager : MonoBehaviour
{
    [SerializeField] private CharacterStat characterStat;
    [SerializeField] private GameObject folder;
    KitchenResourceManagerScript krms;
    public static event Action OnConsumableConsume;

    private void Start()
    {
        characterStat = GameObject.Find("Father").GetComponent<CharacterStat>();
        krms = FindObjectOfType<KitchenResourceManagerScript>();
    }
    private void OnEnable() 
    {
        FatherConsumableUI.OnUseConsumable += UseConsumable;
        CheckIfCharacterDead();
    }

    private void OnDisable()
    {
        FatherConsumableUI.OnUseConsumable -= UseConsumable;
    }
    private void UseConsumable(Item item)
    {
        if(item.itemType == Item.ItemType.Food)
        {
            if(characterStat.HungryCurrentValue == characterStat.HungryMaxValue) return;
            Food food = item as Food;
            characterStat.HungryCurrentValue += food.hungerRestoreAmount;
            OnConsumableConsume?.Invoke();
            HouseInventorySystem.UseItem(item , 1);
        }
        else if(item.itemType == Item.ItemType.Medicine)
        {
            if(characterStat.HealthCurrentValue == characterStat.HealthMaxValue && 
            characterStat.HealthyCurrentValue == characterStat.HealthyMaxValue &&
            characterStat.InfectedCurrentValue == characterStat.InfectedMaxValue) return;
            Medicine medicine = item as Medicine;
            characterStat.HealthCurrentValue += medicine.healAmount;
            characterStat.HealthyCurrentValue += medicine.healthyAmount;
            if(medicine.isCureInfected == true)
            {
                characterStat.InfectedCurrentValue += medicine.infectedAmount;
            }
            OnConsumableConsume?.Invoke();
            HouseInventorySystem.UseItem(item , 1);

        }
        
    }

    public void UseWater()
    {
        if(krms.WaterAmount == 0) return;
        if(krms.WaterAmount >= 1)
        {
            krms.WaterAmount -= 1;
        }
        characterStat.ThirstyCurrentValue += 3;
    }

    public void UseCanFood()
    {
        if(krms.CanFoodAmount == 0) return;
        if (krms.CanFoodAmount >= 1)
        {
            krms.CanFoodAmount -= 1;
        }
        characterStat.HungryCurrentValue += 3;
    }

    private void CheckIfCharacterDead()
    {
        if(characterStat.IsDead == true)
        {
            var components = folder.GetComponentsInChildren<Component>();
            foreach(var component in components)
            {
                var behaivour = component as Behaviour;
                if(behaivour) behaivour.enabled = false;
            }
            folder.SetActive(false);
            
        }
    }





}

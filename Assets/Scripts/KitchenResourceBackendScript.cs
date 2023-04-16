using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenResourceBackendScript : MonoBehaviour
{
    KitchenResourceFrontendScript kitchenResourceFrontendScript;
    [SerializeField] private int _rawFoodAmount = 0 , _cannedFoodAmount = 0 , _medicineAmount = 0 , _waterAmount = 0;
    void Start()
    {
        // Maybe Change Difficulty And this will change
        _rawFoodAmount = 0;
        _cannedFoodAmount = 0;
        _medicineAmount = 0;
        _waterAmount = 0;
    }
    public void ReceiveRawFood(int _amount){
        _rawFoodAmount += _amount;
        Debug.Log("Current Rawfood : " + _rawFoodAmount);
    }

    public void ReceiveCannedFood(int _amount){
        _cannedFoodAmount += _amount;
        Debug.Log("Current Cannedfood : " + _cannedFoodAmount);
    }

    public void ReceiveMedicine(int _amount){
        _medicineAmount += _amount;
        Debug.Log("Current Medicine : " + _medicineAmount);
    }

    public void ReceiveWater(int _amount){
        _waterAmount += _amount;
        Debug.Log("Current Water : " + _waterAmount);
    }
    public void UseRawFood(int _amount){
        if(_rawFoodAmount <= 0) return;
        _rawFoodAmount -= _amount;
        Debug.Log("Current Rawfood : " + _rawFoodAmount);
    }

    public void UseCannedFood(int _amount){
        if(_cannedFoodAmount <= 0) return;
        _cannedFoodAmount -= _amount;
        Debug.Log("Current Cannedfood : " + _cannedFoodAmount);
    }

    public void UseMedicine(int _amount){
        if(_medicineAmount <=0) return;
        _medicineAmount -= _amount;
        Debug.Log("Current Medicine : " + _medicineAmount);
    }

    public void UseWater(int _amount){
        if(_waterAmount <= 0 ) return;
        _waterAmount -= _amount;
        Debug.Log("Current Water : " + _waterAmount);
    }
    
    public int GetRawFoodAmount(){
        return _rawFoodAmount;
    }

    public int GetCannedFoodAmount(){
        return _cannedFoodAmount;
    }

    public int GetMedicineAmount(){
        return _medicineAmount;
    }

    public int GetWaterAmount(){
        return _waterAmount;
    }

}

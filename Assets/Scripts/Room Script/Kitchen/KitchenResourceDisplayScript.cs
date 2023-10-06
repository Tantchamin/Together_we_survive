using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenResourceManagerScript : MonoBehaviour
{
    KitchenResourceDisplayScript kitchenResourceFrontendScript;
    [SerializeField] private int rawFoodAmount = 0 , rawVegetableAmount = 0, canFoodAmount = 0 , 
    medicineAmount = 0 , waterAmount = 0, bandageAmount = 0 , potatoAmount = 0 , carrotAmount  = 0 , tomatoAmount = 0 , cabbageAmount = 0;
    public static event Action OnValueChanged , OnVegetableValueChanged;

    void Start() 
    {
        SetStartingResource();
        SumRawVegetable();   
        OnVegetableValueChanged += SumRawVegetable; 
    }

    private void OnDisable() 
    {
        OnVegetableValueChanged -= SumRawVegetable; 
    }

    private void SumRawVegetable()
    {
        rawVegetableAmount += potatoAmount + cabbageAmount + carrotAmount + tomatoAmount;
    }

    private void SetStartingResource()
    {
        // Maybe Change Difficulty And this will change
        RawFoodAmount = 0;
        RawVegetableAmount = 0;
        CanFoodAmount = 0;
        MedicineAmount = 0;
        BandageAmount = 0;
        PotatoAmount = 0;
        CarrotAmount = 0;
        CabbageAmount = 0;
        TomatoAmount = 0;
    }

    public int RawFoodAmount
    {
        get => rawFoodAmount ; 
        set {
            rawFoodAmount = value;
            OnValueChanged?.Invoke();
    }}
    
    public int RawVegetableAmount
    {
        get => rawVegetableAmount;
        set {
            rawVegetableAmount = value;
            OnValueChanged?.Invoke();
        }
    }
    public int CanFoodAmount
    {
        get => canFoodAmount;
        set{
            cabbageAmount = value;
            OnValueChanged?.Invoke();
        }
    }

    public int MedicineAmount
    {
        get => medicineAmount;
        set {
            medicineAmount = value;
            OnValueChanged?.Invoke();
        }
    }
    public int WaterAmount
    {
        get => waterAmount;
        set{
            waterAmount = value;
            OnValueChanged?.Invoke();
        }
    }
    public int BandageAmount
    {
        get => bandageAmount;
        set{
            bandageAmount = value;
            OnValueChanged?.Invoke();
        }
    }
    public int PotatoAmount
    {
        get => potatoAmount;
        set{
            potatoAmount = value;
            OnVegetableValueChanged?.Invoke();
        }
    }
    public int CarrotAmount
    {
        get => carrotAmount;
        set{
            carrotAmount = value;
            OnVegetableValueChanged?.Invoke();
        }
    }
    public int TomatoAmount
    {
        get => tomatoAmount;
        set{
            tomatoAmount = value;
            OnVegetableValueChanged?.Invoke();
        }
    }
    public int CabbageAmount
    {
        get => cabbageAmount;
        set{
            cabbageAmount = value;
            OnVegetableValueChanged?.Invoke();
        }
    }

    public void ReceiveRawFood(int _amount){
        rawFoodAmount += _amount;
        //Debug.Log("Current Rawfood : " + _rawFoodAmount);
    }    

    public void ReceiveVegetableFood(int _amount)
    {
        rawVegetableAmount += _amount;
        //Debug.Log("Current VegetableFood : " + _vegetableFoodAmount);
    }

    public void ReceiveCannedFood(int _amount){
        canFoodAmount += _amount;
        //Debug.Log("Current Cannedfood : " + _cannedFoodAmount);
    }

    public void ReceiveMedicine(int _amount){
        medicineAmount += _amount;
        //Debug.Log("Current Medicine : " + _medicineAmount);
    }

    public void ReceiveWater(int _amount){
        waterAmount += _amount;
        // Debug.Log("Current Water : " + _waterAmount);
    }

    public void ReceiveBandage(int _amount)
    {
        bandageAmount += _amount;
        //Debug.Log("Current Bandage : " + _bandageAmount);
    }

    public void ReceiveCookedFood(int _amount)
    {
        potatoAmount += _amount;
        //Debug.Log("Current CookedFood : " + _cookedFoodAmount);
    }

    public void UseRawFood(int _amount){
        if(rawFoodAmount <= 0) return;
        rawFoodAmount -= _amount;
        //Debug.Log("Current Rawfood : " + _rawFoodAmount);
    }

    public void UseVegetableFood(int _amount)
    {
        if (rawVegetableAmount <= 0) return;
        rawVegetableAmount -= _amount;
        //Debug.Log("Current Vegetable : " + _vegetableFoodAmount);
    }

    public void UseCannedFood(int _amount){
        if(canFoodAmount <= 0) return;
        canFoodAmount -= _amount;
        //Debug.Log("Current Cannedfood : " + _cannedFoodAmount);
    }

    public void UseMedicine(int _amount){
        if(medicineAmount <=0) return;
        medicineAmount -= _amount;
        //Debug.Log("Current Medicine : " + _medicineAmount);
    }

    public void UseWater(int _amount){
        if(waterAmount <= 0 ) return;
        waterAmount -= _amount;
        //Debug.Log("Current Water : " + _waterAmount);
    }

    public void UseBandage(int _amount)
    {
        if (bandageAmount <= 0) return;
        bandageAmount -= _amount;
        //Debug.Log("Current Bandage : " + _bandageAmount);
    }

    public void UseCookedFood(int _amount)
    {
        if (potatoAmount <= 0) return;
        potatoAmount -= _amount;
        //Debug.Log("Current Bandage : " + _cookedFoodAmount);
    }

    public int GetRawFoodAmount(){
        return rawFoodAmount;
    }

    public int GetVegetableAmount()
    {
        return rawVegetableAmount;
    }

    public int GetCannedFoodAmount(){
        return canFoodAmount;
    }

    public int GetMedicineAmount(){
        return medicineAmount;
    }

    public int GetWaterAmount(){
        return waterAmount;
    }

    public int GetBandageAmount()
    {
        return bandageAmount;
    }

    public int GetCookedFoodAmount(){
        return potatoAmount;
    }

}

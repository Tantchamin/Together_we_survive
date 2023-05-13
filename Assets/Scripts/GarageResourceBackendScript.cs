using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageResourceBackendScript : MonoBehaviour
{
    GarageResourceFrontendScript garageResourceFrontendScript;
    private int _woodAmount, _metalAmount, _tapeAmount, _clotheAmount, 
     _gunComponentAmount,  _gunPowderAmount , _herbAmount;

    [SerializeField] List<int> _garageResource;

    void Start()
    {
        FillResourceToList();
        SetStartingResource();
    }

    public int GetResourceFromList(int _listIndex){
        return _garageResource[_listIndex];
    }

    public void ReceiveResourceToList(int _amount , int _listIndex){
        _garageResource[_listIndex] += _amount;
    }

    public void UseResourceFromList(int _usedAmount , int _listIndex){
        if(_garageResource[_listIndex] <= 0) return;
        _garageResource[_listIndex] -= _usedAmount;
    }

    private void FillResourceToList(){
        _garageResource.Add(_woodAmount); //0
        _garageResource.Add(_metalAmount); 
        _garageResource.Add(_tapeAmount);
        _garageResource.Add(_clotheAmount);
        _garageResource.Add(_gunComponentAmount);
        _garageResource.Add(_gunPowderAmount);
        _garageResource.Add(_herbAmount); //6

    }

    private void SetStartingResource(){
        _woodAmount = 0;
        _metalAmount = 0;  
        _tapeAmount = 0;  
        _clotheAmount = 0; 
        _gunComponentAmount = 0;   
        _gunPowderAmount = 0;
    }

    private void OnEnable() {
        TestEventScript.onGarageResourceButtonClicked += IncreaseWood;
    }

    private void OnDisable() {
        TestEventScript.onGarageResourceButtonClicked -= IncreaseWood;

    }

    void IncreaseWood(){
        _garageResource[0] += 9999;
    }
}

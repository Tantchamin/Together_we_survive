using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageResourceManagerScript : MonoBehaviour
{
    GarageResourceDisplayScript garageResourceDisplayScript;
    private int _woodAmount, _metalAmount, _tapeAmount, _clotheAmount, 
     _gunComponentAmount,  _gunPowderAmount , _herbAmount;

    [SerializeField] List<int> _garageResource;
    private int CheatStartingResource = 100000;
    void Start()
    {
        SetStartingResource();
        FillResourceToList();
        
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
        _woodAmount = CheatStartingResource;
        _metalAmount = CheatStartingResource;  
        _tapeAmount = CheatStartingResource;  
        _clotheAmount = CheatStartingResource; 
        _gunComponentAmount = CheatStartingResource;   
        _gunPowderAmount = CheatStartingResource;
        _herbAmount = CheatStartingResource;
    }

    
}

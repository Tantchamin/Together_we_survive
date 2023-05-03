using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontYardUpgradeHouseManager : MonoBehaviour
{   
    [SerializeField] private GarageResourceBackendScript garageResourceBackendScript;

    private int _woodAmount , _metalAmount , _tapeAmount; //necessary resource for upgrade

    private byte _houseLevel;
    void Start()
    {
        _houseLevel = 0;

    }   

    private void UpdateResource(){
        _woodAmount = garageResourceBackendScript.GetResourceFromList(0);
        _metalAmount = garageResourceBackendScript.GetResourceFromList(1);
        _tapeAmount = garageResourceBackendScript.GetResourceFromList(2);


    }

    public void UpgradeHouse(){
        bool _upgradable = UpgradeHouseCondition(_houseLevel);
        if(_upgradable == true){
            _houseLevel +=1;
            _upgradable = false;
            
        }
    }

    private bool UpgradeHouseCondition(int _level){
        UpdateResource();
        if(_level == 0){
            return HouseLevelOneCondition();
        }
        else if(_level == 1){
            return HouseLevelTwoCondition();
        }
        else if(_level == 2){
            return HouseLevelThreeCondition();
        }

        return false;
    }

    private bool HouseLevelOneCondition(){
        if(_woodAmount < 8) return false;
        else if(_metalAmount <8) return false;
        else if(_tapeAmount < 3) return false;

        garageResourceBackendScript.UseResourceFromList(8,0);
        garageResourceBackendScript.UseResourceFromList(8,1);
        garageResourceBackendScript.UseResourceFromList(8,2);

        return true;
    }

    private bool HouseLevelTwoCondition(){
        if(_woodAmount < 15) return false;
        if(_metalAmount <15) return false;
        if(_tapeAmount < 6) return false;

        garageResourceBackendScript.UseResourceFromList(15,0);
        garageResourceBackendScript.UseResourceFromList(15,1);
        garageResourceBackendScript.UseResourceFromList(6,2);

        return true;
    }

    private bool HouseLevelThreeCondition(){
        if(_woodAmount < 20) return false;
        if(_metalAmount <20) return false;
        if(_tapeAmount < 10) return false;

        garageResourceBackendScript.UseResourceFromList(20,0);
        garageResourceBackendScript.UseResourceFromList(20,1);
        garageResourceBackendScript.UseResourceFromList(10,2);

        return true;
    }

    public byte GetHouseLevel(){
        return _houseLevel;
    }

}

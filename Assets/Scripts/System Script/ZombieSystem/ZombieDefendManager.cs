using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class ZombieDefendManager : MonoBehaviour
{

    //calculate percentage of getting hit from Zombie base on guarded person and weapon.
    [SerializeField] private List<CraftedEquipment> houseEquipmentList;
    [SerializeField] private List<CraftedEquipment> weaponList;

    private byte weaponAmount;
    [SerializeField] private byte hitChance;
    private short zombieHealth = 0;
    private short currentZombieHealth;
    private void Awake() 
    {
        FillToWeaponList();
        GetComponent<ZombieRaidChance>().OnZombieRaid += OnZombieRaid;
    }

    private void OnDisable() 
    {
        GetComponent<ZombieRaidChance>().OnZombieRaid -= OnZombieRaid; 
    }


    private void Start() {
        
    }

    private void OnZombieRaid(byte zombieLevel)
    {
        FillToWeaponList();
        SetZombieHealth(zombieLevel);
        currentZombieHealth = CalculateZombieDamage();
    }

    private void SetZombieHealth(byte zombieLevel)
    {
        ResetZombieHealth();
        zombieLevel += 1;
        zombieHealth = (zombieLevel == 1 ) ? (short) 100 : 
        zombieHealth *= zombieLevel;
        currentZombieHealth = zombieHealth;
    }

    private void ResetZombieHealth ()
    {
        zombieHealth = 100;
        currentZombieHealth = 0;
    }

    private short CalculateZombieDamage()
    {
        weaponAmount = (byte) weaponList.Count;

        return 0;
    }

    //max helath / 100 * percentage

    public void FillToWeaponList()
    {
        
        ClearWeaponList();
        houseEquipmentList = HouseInventorySystem.GetEquipmentListWithOutAMount();
        foreach(CraftedEquipment item in houseEquipmentList)
        {
            if(item.itemType == Equipment.ItemType.Weapon)
            {
                weaponList.Add(item);
            }
        }
    }

    private void ClearWeaponList()
    {
        if(weaponList.Any()) return;
        foreach(CraftedEquipment item in weaponList)
        {
            weaponList.Remove(item);
        }
    }

    private void Update() {
        
    }



   
}

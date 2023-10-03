using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
public class ZombieDefendManager : MonoBehaviour
{

    //calculate percentage of getting hit from Zombie base on guarded person and weapon.
    [SerializeField] private List<Equipment> houseEquipmentList;
    [SerializeField] private List<Weapon> weaponList;
    private byte weaponAmount;
    [SerializeField] private byte hitChance;
    private int zombieHealth = 0 , damage;
    private int currentZombieHealth;
    private byte peopleGuardAmount　=4;

    private ChooseCharacterLabelScript chooseCharacterLabelScript;
    private void Awake() 
    {
        FillToWeaponList();
        GetComponent<ZombieRaidChance>().OnZombieRaid += OnZombieRaid;
        chooseCharacterLabelScript = FindObjectOfType<ChooseCharacterLabelScript>();
    }

    private void OnDisable() 
    {
        GetComponent<ZombieRaidChance>().OnZombieRaid -= OnZombieRaid; 
    }

    public void TestButtonZombieRaid()
    {
        OnZombieRaid(1);
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
        zombieHealth = (zombieLevel == 1 ) ? (short) 100 : 
        zombieHealth *= zombieLevel;
        currentZombieHealth = (int) zombieHealth;
        Debug.Log($"Zombie health : {zombieHealth}");
    }

    private void ResetZombieHealth ()
    {
        zombieHealth = 0;
        currentZombieHealth = 0;
    }

    private void FillToWeaponList()
    {
        ClearWeaponList();
        weaponList = HouseInventorySystem.GetWeaponList();
        
    }

    private void ClearWeaponList()
    {
        if(weaponList.Any()) return;
        foreach(Weapon item in weaponList)
        {
            weaponList.Remove(item);
        }
    }

    private int CalculateZombieDamage()
    {
        var weaponListOrdered = weaponList.OrderByDescending(weapon => weapon.damage);
        
        byte counter = 0;
        byte Maxcounter = GetPeopleGuardAmount();
        ResetDamage();
        foreach(Weapon weapon in weaponListOrdered)
        {
            // Debug.Log("weapon " + weapon.equipmentName);
            damage += (short) weapon.damage;
            counter += 1;
            if(counter >= peopleGuardAmount) break;
        }
        counter = 0;
    
        return damage;
    }

    private byte GetPeopleGuardAmount()
    {



        return peopleGuardAmount;
    }

    private void ResetDamage()
    {
        damage = 0;
    }

    //max helath / 100 * percentage

    

    private void Update() {
        
    }



   
}

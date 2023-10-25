using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
public class ZombieDefendManager : MonoBehaviour
{

    //calculate percentage of getting hit from Zombie base on guarded person and weapon.
    [SerializeField] private List<Item> houseEquipmentList , preWeaponList;
    [SerializeField] private List<Weapon> weaponList;
    private byte weaponAmount;
    [SerializeField] private byte hitChance , testZombieLevel;
    
    private int zombieHealth = 0 , damage;
    private int currentZombieHealth;
    private byte peopleGuardAmount = 0;
    private byte peopleUnarmedDamage = 50;
    public event Action<int> OnZombieDamage;

    private ChooseCharacterManager chooseCharacterManagerScript;
    private void Awake() 
    {
        FillToWeaponList();
        GetComponent<ZombieRaidChance>().OnZombieRaid += OnZombieRaid;
        chooseCharacterManagerScript = FindObjectOfType<ChooseCharacterManager>();
    }

    private void OnDisable() 
    {
        GetComponent<ZombieRaidChance>().OnZombieRaid -= OnZombieRaid; 
    }

    public void TestButtonZombieRaid()
    {
        OnZombieRaid(testZombieLevel);
    }

    private void OnZombieRaid(byte _zombieLevel)
    {
        FillToWeaponList();
        currentZombieHealth = SetZombieHealth(_zombieLevel);
        damage = CalculateZombieDamage();
        CalculateZombieHealth(currentZombieHealth , damage);
        byte _damage = (byte)CalculateZombieHealth(currentZombieHealth , damage);
        if (_damage == 0) return;
        OnZombieDamage?.Invoke(_damage);
    }

    private int SetZombieHealth(byte zombieLevel)
    {
        ResetZombieHealth();
        zombieHealth = 100;
        Debug.Log($"Zombielevel : {zombieLevel}");
        zombieHealth = (zombieLevel == 1 ) ? (short) 100 : 
        zombieHealth *= zombieLevel;
        currentZombieHealth = (int) zombieHealth;
        Debug.Log($"Zombie health : {zombieHealth}");
        return currentZombieHealth;
    }

    private void ResetZombieHealth ()
    {
        zombieHealth = 0;
        currentZombieHealth = 0;
    }

    private void FillToWeaponList()
    {
        ClearWeaponList();
        preWeaponList = HouseInventorySystem.GetWeaponList();
        foreach(Item item in preWeaponList)
        {
            Weapon weapon = item as Weapon;
            weaponList.Add(weapon);
        }
        
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
        peopleGuardAmount = GetPeopleGuardAmount();
        Debug.Log($"People guard amoujt {peopleGuardAmount}");
        ResetDamage();
        foreach(Weapon weapon in weaponListOrdered)
        {
            damage += (short) weapon.damage;
            counter += 1;
            
            if(counter >= peopleGuardAmount) break;
        }
        if(counter < peopleGuardAmount)
        {
            damage += (peopleGuardAmount - counter) * peopleUnarmedDamage;
        }
        counter = 0;
        
        Debug.Log($"Damage : {damage}");
        return damage;
    }

    private int CalculateZombieHealth(int currentZombieHealth , int damage)
    {
        zombieHealth = currentZombieHealth - damage;
        if(zombieHealth <= 0) zombieHealth = 0;
        Debug.Log($"Total zombie health before passing {zombieHealth}");
        return zombieHealth;
    }

    private byte GetPeopleGuardAmount()
    {
        return chooseCharacterManagerScript.GetGuardPeopleAmount();;
    }

    private void ResetDamage()
    {
        damage = 0;
    }

    //max helath / 100 * percentage

    

    private void Update() {
        
    }



   
}

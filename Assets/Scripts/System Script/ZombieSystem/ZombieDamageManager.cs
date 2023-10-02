using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamageManager : MonoBehaviour
{
    [SerializeField] private CharacterStatScript _father;
    [SerializeField] private CharacterStatScript _mother;
    [SerializeField] private CharacterStatScript _sister;
    [SerializeField] private CharacterStatScript _brother;
    private int randomNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void randomAttackChance(CharacterStatScript character)
    {
        randomNumber = Random.Range(0, 101);
        Debug.Log("Attack Chance: " + randomNumber);
        if(randomNumber <= 60)
        {
            character.CharacterHealthAdjust(-1);
        }
    }

    public void EndRaidButton(GameObject zommbieRaidUI)
    {
        randomAttackChance(_father);
        randomAttackChance(_mother);
        randomAttackChance(_sister);
        randomAttackChance(_brother);
        zommbieRaidUI.SetActive(false);        
    }
}

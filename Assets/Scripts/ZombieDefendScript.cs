using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDefendScript : MonoBehaviour
{
    [SerializeField] private CharacterStatScript _father;
    [SerializeField] private CharacterStatScript _mother;
    [SerializeField] private CharacterStatScript _sister;
    [SerializeField] private CharacterStatScript _brother;
    private int randomNumber;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndRaidButton(GameObject zommbieRaidUI)
    {
        randomAttackChance(_father);
        randomAttackChance(_mother);
        randomAttackChance(_sister);
        randomAttackChance(_brother);
        zommbieRaidUI.SetActive(false);        
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
}

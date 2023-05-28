using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDefendScript : MonoBehaviour
{
    [SerializeField] private CharacterStatScript _father;
    [SerializeField] private CharacterStatScript _mother;
    [SerializeField] private CharacterStatScript _sister;
    [SerializeField] private CharacterStatScript _brother;


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
        zommbieRaidUI.SetActive(false);        
    }

    private void randomAttackLevel()
    {

    }
}

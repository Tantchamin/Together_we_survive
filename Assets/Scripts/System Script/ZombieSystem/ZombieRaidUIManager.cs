using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRaidUIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> zombieRaidUI;

    private void Awake() 
    {
        GetComponent<ZombieRaidChance>().OnZombieRaid += ActiveUI;
    }

    private void OnDisable() 
    {
        GetComponent<ZombieRaidChance>().OnZombieRaid -= ActiveUI;       
    }

    private void ActiveUI(byte zombieLevel)
    {
        Debug.Log($"Zombie level {zombieLevel}");
        zombieRaidUI[zombieLevel].gameObject.SetActive(true);
    }

    public void UnActiveUI ()
    {
        foreach (GameObject ui in zombieRaidUI)
        {
            ui.gameObject.SetActive(false);
        }
    }
}

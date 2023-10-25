using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherMotherSisterDeadEnding : MonoBehaviour, IEnding
{
    [SerializeField] private GameObject ending;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == true && EndingManageScript.IsMotherDead == true && 
        EndingManageScript.IsSisterDead == true && EndingManageScript.IsBrotherDead == false)
        {
            ending.SetActive(true);
        }
    }
}
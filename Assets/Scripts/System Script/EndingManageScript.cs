using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManageScript : MonoBehaviour
{
    [SerializeField] private CharacterStat _father, _mother, _sister, _brother;
    [SerializeField] private GameObject _ending1_BadEnd;

    private void Start()
    {
        _ending1_BadEnd.SetActive(false);
    }

    private void Update()
    {
        // if(_father.GetIsDead() == true && _mother.GetIsDead() == true && _sister.GetIsDead() == true && _brother.GetIsDead() == true)
        // {
        //     _ending1_BadEnd.SetActive(true);
        // }
    }
}

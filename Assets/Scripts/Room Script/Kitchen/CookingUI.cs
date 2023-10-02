using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingUI : MonoBehaviour
{
    [SerializeField] private GameObject _cookingPanel;
    void Start()
    {
        _cookingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

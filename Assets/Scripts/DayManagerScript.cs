using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayManagerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dayText;
    private int _dayNumber = 1;

    void Update()
    {
        _dayText.text = "Day " + _dayNumber;
    }

    public void DayIncrese(int _day)
    {
        _dayNumber += _day;
    }

}

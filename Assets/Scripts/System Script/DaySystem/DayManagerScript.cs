using UnityEngine;
using TMPro;

public class DayManagerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dayText;
    private int _dayNumber = 1;

    void Update()
    {
        _dayText.text = "Day " + _dayNumber;
    }

    public void IncreaseDays(int _day)
    {
        _dayNumber += _day;
    }

    public int GetDays()
    {
        return _dayNumber;
    }

}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayDisplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;   
    private void Awake() {
        DayManagerScript.OnDayEnd += UpdateDay;
    }
    private void UpdateDay()
    {
        dayText.text = "Day : " + DayManagerScript.GetDays();
    }
}

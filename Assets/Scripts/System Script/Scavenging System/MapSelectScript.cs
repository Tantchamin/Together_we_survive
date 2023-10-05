using System;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectScript : MonoBehaviour
{
    [SerializeField] private Toggle villageToggle;
    [SerializeField] private Toggle marketToggle;
    [SerializeField] private Toggle hospitalToggle;
    [SerializeField] private Toggle gasStationToggle;
    [SerializeField] private GarageResourceManagerScript garageResourceManagerScript;
    [SerializeField] private KitchenResourceManagerScript kitchenResorceManagerScript;
    [SerializeField] private DayManagerScript dayManagerScript;
    ChooseCharacterManager chooseCharacterManager;

    // public event Action OnDayStart;

    private void Awake()
    {
        garageResourceManagerScript.GetComponent<GarageResourceManagerScript>();
        kitchenResorceManagerScript.GetComponent<KitchenResourceManagerScript>();
        dayManagerScript =FindAnyObjectByType<DayManagerScript>();
    }
    private void Start()
    {
        chooseCharacterManager = GameObject.FindGameObjectWithTag("ChooseCharacterManager").GetComponent<ChooseCharacterManager>();
    }

    public void NextDayButtonClick()
    {
        if (villageToggle.isOn == true)
        {
            for(int i = 0; i < 10; i++)
            {
                int randomNumber = UnityEngine.Random.Range(1, 101);
                switch (randomNumber)
                {
                    case <=25:
                        garageResourceManagerScript.ReceiveResourceToList(1, 0);
                        break;

                    case <=45:
                        garageResourceManagerScript.ReceiveResourceToList(1, 1);
                        break;

                    case <=55:
                        garageResourceManagerScript.ReceiveResourceToList(1, 5);
                        break;

                    case <=70:
                        garageResourceManagerScript.ReceiveResourceToList(1, 6);
                        break;

                    case <=80:
                        kitchenResorceManagerScript.ReceiveRawFood(1);
                        break;

                    case <=90:
                        kitchenResorceManagerScript.ReceiveCannedFood(1);
                        break;

                    case <=100:
                        kitchenResorceManagerScript.ReceiveWater(1);
                        break;

                }

            }
            gameObject.SetActive(false);
        }
        else if (marketToggle.isOn == true)
        {
            for (int i = 0; i < 10; i++)
            {
                int randomNumber = UnityEngine.Random.Range(1, 101);
                switch (randomNumber)
                {
                    case <=20:
                        garageResourceManagerScript.ReceiveResourceToList(1, 1);
                        break;

                    case <=30:
                        garageResourceManagerScript.ReceiveResourceToList(1, 2);
                        break;

                    case <=50:
                        garageResourceManagerScript.ReceiveResourceToList(1, 3);
                        break;

                    case <=60:
                        kitchenResorceManagerScript.ReceiveRawFood(1);
                        break;

                    case <=70:
                        kitchenResorceManagerScript.ReceiveVegetableFood(1);
                        break;

                    case <=80:
                        kitchenResorceManagerScript.ReceiveCannedFood(1);
                        break;

                    case <=95:
                        kitchenResorceManagerScript.ReceiveWater(1);
                        break;

                    case <= 100:
                        kitchenResorceManagerScript.ReceiveBandage(1);
                        break;

                }

            }
            gameObject.SetActive(false);
        }
        else if(hospitalToggle.isOn == true)
        {
            for (int i = 0; i < 10; i++)
            {
                int randomNumber = UnityEngine.Random.Range(1, 101);
                switch (randomNumber)
                {
                    case <= 5:
                        garageResourceManagerScript.ReceiveResourceToList(1, 2);
                        break;

                    case <= 15:
                        garageResourceManagerScript.ReceiveResourceToList(1, 3);
                        break;

                    case <= 35:
                        garageResourceManagerScript.ReceiveResourceToList(1, 3);
                        break;

                    case <= 45:
                        kitchenResorceManagerScript.ReceiveWater(1);
                        break;

                    case <= 75:
                        kitchenResorceManagerScript.ReceiveMedicine(1);
                        break;

                    case <= 100:
                        kitchenResorceManagerScript.ReceiveBandage(1);
                        break;

                }

            }
            gameObject.SetActive(false);
        }
        else if(gasStationToggle.isOn == true)
        {
            for (int i = 0; i < 10; i++)
            {
                int randomNumber = UnityEngine.Random.Range(1, 101);
                switch (randomNumber)
                {
                    case <= 25:
                        garageResourceManagerScript.ReceiveResourceToList(1, 0);
                        break;

                    case <= 45:
                        garageResourceManagerScript.ReceiveResourceToList(1, 1);
                        break;

                    case <= 55:
                        garageResourceManagerScript.ReceiveResourceToList(1, 5);
                        break;

                    case <= 70:
                        garageResourceManagerScript.ReceiveResourceToList(1, 6);
                        break;

                    case <= 80:
                        kitchenResorceManagerScript.ReceiveRawFood(1);
                        break;

                    case <= 90:
                        kitchenResorceManagerScript.ReceiveCannedFood(1);
                        break;

                    case <= 100:
                        kitchenResorceManagerScript.ReceiveWater(1);
                        break;

                }

            }
            gameObject.SetActive(false);
        }

        dayManagerScript.IncreaseDays();

    }
}

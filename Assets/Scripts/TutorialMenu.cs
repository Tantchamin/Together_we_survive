using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> tutorialPages;
    [SerializeField] private GameObject nextButton, backButton;
    [SerializeField] private GameObject tutorialMenu;
    private int pageNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <= tutorialPages.Count-1; i++)
        {
            if(i == pageNumber)
            {
                tutorialPages[i].SetActive(true);
            }
            else
            {
                tutorialPages[i].SetActive(false);
            }
        }

        if(pageNumber == 0)
        {
            backButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else if(pageNumber > 0 && pageNumber < tutorialPages.Count-1)
        {
            backButton.SetActive(true);
            nextButton.SetActive(true);
        }
        else
        {
            backButton.SetActive(true);
            nextButton.SetActive(false);
        }
    }

    public void ChangePage(int number)
    {
        pageNumber += number;
    }

    public void SetActiveTutorialMenu(bool isActive)
    {
        tutorialMenu.SetActive(isActive);
    }
}

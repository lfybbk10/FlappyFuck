using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Settings settings;
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private GameObject diffButtons;

    public void StartGame()
    {
        
    }
    
    public void ChangeDifficulty()
    {
        menuButtons.SetActive(false);
        diffButtons.SetActive(true);
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        menuButtons.SetActive(true);
        diffButtons.SetActive(false);
    }

    public void ChooseEasyDiff()
    {
        settings.changeDiff("Easy");
    }
    
    public void ChooseMidDiff()
    {
        settings.changeDiff("Mid");
    }
    
    public void ChooseHardDiff()
    {
        settings.changeDiff("Hard");
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Settings settings;
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private GameObject diffButtons;
    [SerializeField] private TextMeshProUGUI currentDIffText;

    public void ChangeDifficulty()
    {
        menuButtons.SetActive(false);
        diffButtons.SetActive(true);
    }

    private void Start()
    {
         currentDIffText.SetText($"Текущая сложность : {translateText()}");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
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
        currentDIffText.SetText($"Текущая сложность : {translateText()}");
    }
    
    public void ChooseMidDiff()
    {
        settings.changeDiff("Mid");
        currentDIffText.SetText($"Текущая сложность : {translateText()}");
    }
    
    public void ChooseHardDiff()
    {
        settings.changeDiff("Hard");
        currentDIffText.SetText($"Текущая сложность : {translateText()}");
    }
    
    public string translateText()
    {
        switch (settings.currentDifficult.name)
        {
            case "Easy":
                return "Лёгкий";
            case "Mid":
                return "Средний";
            case "Hard":
                return "Сложный";
            default:
                return "хуёво";
        }
    }
    
}

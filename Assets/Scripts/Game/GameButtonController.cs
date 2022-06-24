using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Game
{
    public class GameButtonController : MonoBehaviour
    {
        private Settings settings;
        [SerializeField] private TextMeshProUGUI currentDiffText;
        [SerializeField] private GameObject endMenuButtons;
        [SerializeField] private GameObject diffButtons;

        private void Start()
        {
            settings = GameObject.Find("Settings").GetComponent<Settings>();
            currentDiffText.SetText($"Текущая сложность: {translateText()}");
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void ChangeDifficulty()
        {
            endMenuButtons.SetActive(false);
            diffButtons.SetActive(true);
        }

        public void ExitToMenu()
        {
            SceneManager.LoadScene("MenuScene");
        }

        public void Back()
        {
            endMenuButtons.SetActive(true);
            diffButtons.SetActive(false);
        }

        public void ChooseEasyDiff()
        {
            settings.changeDiff("Easy");
            currentDiffText.SetText($"Текущая сложность: {translateText()}");
        }
    
        public void ChooseMidDiff()
        {
            settings.changeDiff("Mid");
            currentDiffText.SetText($"Текущая сложность: {translateText()}");
        }
    
        public void ChooseHardDiff()
        {
            settings.changeDiff("Hard");
            currentDiffText.SetText($"Текущая сложность: {translateText()}");
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
}
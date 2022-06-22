using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    private float lastTryTime;
    private static int countTries;
    [SerializeField] public TextMeshProUGUI lastTryTimeText;
    [SerializeField] public TextMeshProUGUI countTriesText;
    

    public void ResetStats()
    {
        countTries++;
        lastTryTimeText.SetText($"Время последней попытки: {Math.Round(lastTryTime,2)} сек.");
        countTriesText.SetText($"Количество попыток: {countTries}");
        lastTryTime = 0;
    }
    private void Update()
    {
        lastTryTime += Time.deltaTime;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Settings : MonoBehaviour
{
    private DifficultyInfo[] difficults;
    public DifficultyInfo currentDifficult;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        difficults = Resources.LoadAll<DifficultyInfo>("");
        currentDifficult = difficults.Where(x=>x.name.Equals("Easy")).First();
    }

    public void changeDiff(string diff)
    {
        currentDifficult = difficults.Where(x=>x.name.Equals(diff)).First();
    }
}

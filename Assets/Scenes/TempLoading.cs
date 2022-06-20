using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempLoading : MonoBehaviour
{
    public void LoadingScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}

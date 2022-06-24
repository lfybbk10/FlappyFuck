using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CheckPlayerCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            GameObject.Find("EndGameCanvas").transform.FindChild("StatsContainer").gameObject.SetActive(true);
            GameObject.Find("MainCanvas").transform.FindChild("UpButton").gameObject.SetActive(false);
            GameObject.Find("Stats").GetComponent<GameStats>().ResetStats();
            Destroy(gameObject);
        }
    }
}
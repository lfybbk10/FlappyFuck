using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CheckPlayerCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            //StartCoroutine(BlockExit());
            GameObject.Find("EndGameCanvas").transform.FindChild("StatsContainer").gameObject.SetActive(true);
            GameObject.Find("MainCanvas").transform.FindChild("UpButton").gameObject.SetActive(false);
            GameObject.Find("Stats").GetComponent<GameStats>().ResetStats();
            Destroy(gameObject);
        }

        private IEnumerator BlockExit()
        {
            GameObject.Find("EndGameCanvas").transform.FindChild("StatsContainer").transform.FindChild("Exit")
                .GetComponent<Button>().enabled = false;
            yield return new WaitForSecondsRealtime(1.5f);
            print("хуй");
            GameObject.Find("EndGameCanvas").transform.FindChild("StatsContainer").transform.FindChild("Exit")
                .GetComponent<Button>().enabled = true;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class CloudController : MonoBehaviour
{
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private GameObject wallsPrefab;
    [SerializeField] private WallsContorller wallsContorller;
    private float speed;
    private List<GameObject> spawnedClouds;
    private int minHeight;
    private int maxHeight;
    [SerializeField] private float spawnLenght;
    private RectTransform cloudPrefabRectTransform;
    
    private void Start()
    {
        spawnedClouds = new List<GameObject>();
        cloudPrefabRectTransform = cloudPrefab.GetComponent<RectTransform>();
        minHeight = (int) ((wallsPrefab.transform.position.y + wallsPrefab.GetComponent<RectTransform>().rect.height / 100 + cloudPrefab.GetComponent<RectTransform>().rect.height / 100 * 9f) * 3.2f);
        maxHeight = (int) ((wallsPrefab.transform.position.y + wallsPrefab.GetComponent<RectTransform>().rect.height / 100 + cloudPrefab.GetComponent<RectTransform>().rect.height / 100 * 16f) * 4f) ;
        PoolManager.WarmPool(cloudPrefab, 20);
        speed = wallsContorller.speed;
        Random random = new Random();
        for (int i = 1; i <= 10; i++)
        {
            float yAdditional = (float)random.NextDouble();
            float yFinal = random.Next(minHeight, maxHeight) + yAdditional;
            var cloud = PoolManager.SpawnObject(cloudPrefab, new Vector3(spawnLenght * i, yFinal, 6),
                Quaternion.identity);
            cloud.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            spawnedClouds.Add(cloud);
        }
    }
    
    
    private void Update()
    {
        Random random = new Random();
        foreach (var cloud in spawnedClouds)
        {
            if (cloud.transform.position.x < (-12.4f - cloudPrefabRectTransform.rect.width / 100) * 1.2f)
            {
                float yAdditional = (float)random.NextDouble();
                float yFinal = random.Next(minHeight, maxHeight) + yAdditional;
                PoolManager.ReleaseObject(cloud);
                spawnedClouds.Remove(cloud);
                var spawnedCloud =  PoolManager.SpawnObject(cloudPrefab,
                    new Vector3(spawnedClouds.Select(obj => obj.transform.position.x).Max() + spawnLenght, yFinal,
                        6), Quaternion.identity);
                spawnedClouds.Add(spawnedCloud);
                spawnedCloud.GetComponent<Rigidbody2D>().velocity = Vector2.left * (speed - 1.5f);
                break;
            }
        }
            
    }
}

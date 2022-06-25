using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MonsterLove.Collections;
using UnityEngine;
using Random = System.Random;

public class BarrierPool : MonoBehaviour
{
    [SerializeField] private GameObject barrierPrefab;
    private Settings settings;
    [SerializeField] private GameObject wallsPrefab;
    private int minHeight;
    private int maxHeight;
    private float spawnLenght;
    private float speed;
    private List<GameObject> spawnedBarriers;
    private RectTransform barrierPrefabRectTransform;
    [SerializeField] private WallsContorller wallsContorller;
    
    private void Start()
    {
        settings = GameObject.Find("Settings").GetComponent<Settings>();
        spawnLenght = settings.currentDifficult.distToSpawnBarrier;
        barrierPrefabRectTransform = barrierPrefab.GetComponent<RectTransform>();
        spawnedBarriers = new List<GameObject>();
        minHeight = (int) (wallsPrefab.transform.position.y - wallsPrefab.GetComponent<RectTransform>().rect.height / 100 * 1.3) - 1;
        maxHeight = (int) (wallsPrefab.transform.position.y + wallsPrefab.GetComponent<RectTransform>().rect.height / 100 * 2.25) - 1;
        
        PoolManager.WarmPool(barrierPrefab, 20);
        speed = wallsContorller.speed;
        Random random = new Random();
        for (int i = 1; i <= 10; i++)
        {
            float yAdditional = (float)random.NextDouble();
            float yFinal = random.Next(minHeight, maxHeight) + yAdditional;
           var barrier = PoolManager.SpawnObject(barrierPrefab, new Vector3(spawnLenght * i, yFinal, 6),
                Quaternion.identity);
           barrier.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
           spawnedBarriers.Add(barrier);
        }
    }

    private void Update()
    {
        Random random = new Random();
        if (speed != wallsContorller.speed)
        {
            speed = wallsContorller.speed;
            foreach (var barrier in spawnedBarriers)
            {
                barrier.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            }
        }

        foreach (var barrier in spawnedBarriers)
        {
            if (barrier.transform.position.x < -12.4f - barrierPrefabRectTransform.rect.width / 100)
            {
                float yAdditional = (float)random.NextDouble();
                float yFinal = random.Next(minHeight, maxHeight) + yAdditional;
                PoolManager.ReleaseObject(barrier);
                spawnedBarriers.Remove(barrier);
               var spawnedBarrier =  PoolManager.SpawnObject(barrierPrefab,
                    new Vector3(spawnedBarriers.Select(obj => obj.transform.position.x).Max() + spawnLenght, yFinal,
                        6), Quaternion.identity);
                spawnedBarriers.Add(spawnedBarrier);
                spawnedBarrier.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
                break;
            }
        }
            
    }
}

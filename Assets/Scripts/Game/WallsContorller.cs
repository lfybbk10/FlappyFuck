using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WallsContorller : MonoBehaviour
{
   [SerializeField] private GameObject wallsPrefab;
   private GameObject walls;
   private Rigidbody2D wallsRigidBody;
   
   private GameObject nextWalls;
   private Rigidbody2D nextWallsRigidBody;
   
   private Settings settings;

   public float speed;
   private float speedChangeTimer = 0;

   private void Start()
   {
      settings = GameObject.Find("Settings").GetComponent<Settings>();
      walls = Instantiate(wallsPrefab, new Vector3(-3.4f, 0, 9), Quaternion.identity);
      wallsRigidBody = walls.GetComponent<Rigidbody2D>();
      
      nextWalls = Instantiate(wallsPrefab, new Vector3(-3.4f*-4, 0, 9), Quaternion.identity);
      nextWallsRigidBody = nextWalls.GetComponent<Rigidbody2D>();

      speed = settings.currentDifficult.speed;
   }

   private void Update()
   {
      speedChangeTimer += Time.deltaTime;
      if (speedChangeTimer>=settings.currentDifficult.timeToChangeSpeed)
      {
         speedChangeTimer = 0;
         speed += 1.5f;
         speed = Mathf.Clamp(speed, 0, 60);
      }
      
      wallsRigidBody.velocity = Vector2.left * speed;
      nextWallsRigidBody.velocity = Vector2.left * speed;

      if (walls.transform.position.x < -3.425f * 6)
      {
         float lastX = walls.transform.position.x;
         float lol = lastX - (-3.425f * 6);
         Destroy(walls);
         
         walls = nextWalls;
         wallsRigidBody = nextWallsRigidBody;
         
         nextWalls = Instantiate(wallsPrefab, new Vector3(-3.4f*-4 + lol,0, 9), Quaternion.identity);
         nextWallsRigidBody = nextWalls.GetComponent<Rigidbody2D>();
      }
   }
}

using System;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    [SerializeField] private GameObject playerPrefab;
    private bool isMouseDown;
    private Rigidbody2D playerRigidbody2D;
    private float gameTime;

    public void OnPointerDown(PointerEventData eventData)
    {
        isMouseDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isMouseDown = false;
    }

    private void Start()
    {
        var player = Instantiate(playerPrefab,new Vector3(-11, 0, 9), Quaternion.identity);
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        playerRigidbody2D.gravityScale = 0;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        
        if (gameTime > 1.5f && playerRigidbody2D != null)
            playerRigidbody2D.gravityScale = 1f;
        
        if (isMouseDown && gameTime > 1.5f && playerRigidbody2D != null)
        {
            playerRigidbody2D.AddForce(Vector2.up * 3.2f);
        }
    }

    
}
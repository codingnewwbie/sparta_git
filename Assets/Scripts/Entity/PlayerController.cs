using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;
    
    private GameManager gameManager;
    
    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        camera = Camera.main;
    }
    
    private void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }
    
    private void OnLook(InputValue inputValue)
    {
        Vector2 mousePosition = inputValue.Get<Vector2>();
        Vector2 worldPosition = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPosition - (Vector2)transform.position);
        
        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
    
    private void OnJump(InputValue inputValue)
    {
        // UI에 마우스가 올라가 있으면 이벤트 점프 멈춤
        // if (EventSystem.current.IsPointerOverGameObject())
        // {
        //     return;
        // }
        isJumpping = inputValue.isPressed;
    }
    
}

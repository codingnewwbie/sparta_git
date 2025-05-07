using System;
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

    private NPCController currentNPC;
    
    [SerializeField] private Animator playerAnimator;
    
    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        camera = Camera.main;
    }
    
    private void Start() {
        int skinIndex = PlayerPrefs.GetInt("SkinIndex", 0);
        if (skinIndex == 1)
        {
            playerAnimator.SetTrigger("IsSkin");
        }
    }
    
    private void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        
        if (isBattle)
        {
            movementDirection = movementDirection.normalized;
        }
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
    
    
    public void OnTalk(InputValue value)
    {
        if (currentNPC != null && value.isPressed)
        {
            currentNPC.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            currentNPC = collision.GetComponent<NPCController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            if (currentNPC != null && currentNPC.gameObject == collision.gameObject)
            {
                currentNPC = null;
            }
        }
    }
}

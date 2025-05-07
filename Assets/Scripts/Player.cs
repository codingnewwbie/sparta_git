using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpped = 3f;
    public bool isDead = false;
    private float deathCooldown = 0f;

    private bool isFlap = false;

    public bool godMode = false;
    
    GameManager gameManager;
    
    void Start()
    {
        gameManager = GameManager.Instance;
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        
        if (_animator == null)
            Debug.LogError("Not Founded Animator");
        
        if (_rigidbody == null)
            Debug.LogError("Not Founded Rigidbody");
    }

    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }


    private void FixedUpdate()
    {
        if (isDead) return;
        
        // velocity.x를 일정하게 유지. +=는 점점 속도가 빨라짐
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpped;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        
        
        _rigidbody.velocity = velocity;
        
        // angle 각을 y값 * 10(너무 작으면 회전값이 잘 안보임)을 이용해서 구하는데, -90 ~ 90.
        float angle = Mathf.Clamp( (_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    //collision을 비교하지 않는 이유는 Collider 달고 있는 무엇이든 충돌하면 게임오버되도록.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;
        
        _animator.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }
}

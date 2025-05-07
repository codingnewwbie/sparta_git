using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    // [SerializeField] private Transform weaponPivot;

    protected Vector2 movementDirection = Vector2.zero;

    public Vector2 MovementDirection
    {
        get => movementDirection;
    }

    protected Vector2 lookDirection = Vector2.zero;

    public Vector2 LookDirection
    {
        get => lookDirection;
    }

    // private Vector2 knockback = Vector2.zero;
    // private float knockbackDuration = 0f;

    protected AnimatorController animator;
    protected StatController statController;

    private float jumpPower = 6f;
    protected bool isJumpping;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<AnimatorController>();
        statController = GetComponent<StatController>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        HandleJumpDelay();
    }

    protected virtual void HandleAction()
    {

    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    private void Movement(Vector2 direction)
    {

        direction = direction * statController.Speed;
        // 넉백을 적용해야 한다면 기존의 움직이는 힘은 줄여주고 넉백을 적용하겠다.
        // if (knockbackDuration > 0f)
        // {
        //     direction *= 0.2f;
        //     direction += knockback;
        // }

        // 이동에 대한 처리. 빠지면 입력은 받는데 실제로 움직이진 않음.
        // _rigidbody.velocity = direction;
        
        float newX = direction.x;
        float newY = isJumpping ? _rigidbody.velocity.y : direction.y; // 점프 중이면 기존 y 유지

        
        _rigidbody.velocity = new Vector2(newX, newY);
        animator.Move(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 아크탄젠트 절대값이 90 이상이다 = 왼쪽을 바라보고 있다.
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        //이미지 뒤집힘
        characterRenderer.flipX = isLeft;

        // if (weaponPivot != null)
        // {
        //     // 디그리 값을 가지고 있어서
        //     weaponPivot.rotation = Quaternion.Euler(0f, 0f, rotZ);
        // }
        //
        // weaponHandler?.Rotate(isLeft);

    }

    private void Jump()
    {
        if (isJumpping)
        {
            Vector3 velocity = _rigidbody.velocity;
            Debug.Log("점프값 처리가 안되나? 처리전 x" + velocity.x);
            Debug.Log("점프값 처리가 안되나? 처리전 y" + velocity.y);
            velocity.y += jumpPower;
            
            _rigidbody.velocity = velocity;
            Debug.Log("점프값 처리가 안되나? 처리후 x" + _rigidbody.velocity.x);
            Debug.Log("점프값 처리가 안되나? 처리후 y" + _rigidbody.velocity.y);
            isJumpping = false;
            
            
        }
    }
    
    
    private void HandleJumpDelay()
    {
        if (statController == null)
        {
            return;
        }

        if (statController.TimeSinceLastJump <= statController.Delay)
        {
            statController.TimeSinceLastJump += Time.deltaTime;
        }

        if (isJumpping &&  statController.TimeSinceLastJump > statController.Delay)
        {
            statController.TimeSinceLastJump = 0;
            Jump();
        }
    }
}

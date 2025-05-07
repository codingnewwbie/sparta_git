using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    
    [SerializeField] protected bool isBattle = false;
    
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

    protected bool isTalking;

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

        // 이동에 대한 처리. 빠지면 입력은 받는데 실제로 움직이진 않음.
        _rigidbody.velocity = direction;
        animator.Move(direction);

        if (!isBattle && direction.x > 0.01f)
        {
            characterRenderer.flipX = false;
        }
        else if (!isBattle && direction.x < -0.01f)
        {
            characterRenderer.flipX = true;
        }
    }

    private void Rotate(Vector2 direction)
    {
        if(isBattle) {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 아크탄젠트 절대값이 90 이상이다 = 왼쪽을 바라보고 있다.
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        //이미지 뒤집힘
        characterRenderer.flipX = isLeft;

        }

    }
}

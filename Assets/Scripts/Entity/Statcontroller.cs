using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    // 나중에 쓸 수 있으니까
    // [Range(1, 100)] [SerializeField] private int health = 10;
    //
    // public int Health
    // {
    //     get => health;
    //     set => health = Mathf.Clamp(value, 0, 100);
    // }
    
    [Range(1f, 20f)] [SerializeField] private float speed = 3;

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }
    
    private float delay = 1f;

    public float Delay
    {
        get => delay;
        set => delay = value;
    }

    private float timeSinceLastJump = float.MaxValue;
    
    public float TimeSinceLastJump
    {
        get => timeSinceLastJump;
        set => timeSinceLastJump = value;
    }

}

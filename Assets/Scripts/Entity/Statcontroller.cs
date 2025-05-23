using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    [Range(1f, 20f)] [SerializeField] private float speed = 3;

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }
    
    public void SetSpeed(float newSpeed)
    {
        speed = Mathf.Clamp(newSpeed, 1f, 20f);
    }
    
}

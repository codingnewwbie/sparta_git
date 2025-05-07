using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private static readonly int IsMove = Animator.StringToHash("IsMove");
    
    protected Animator animator;
    
    protected virtual void Awake()
    {
       animator = GetComponentInChildren<Animator>();
    }
 
    public void Move(Vector2 obj)
    {
       animator.SetBool(IsMove, obj.magnitude > 0.5f);
    }
    
       // public void Damage()
       // {
       //    animator.SetBool(IsDamage, true);
       // }
       //
       // public void InvincibilityEnd()
       // {
       //    animator.SetBool(IsDamage, false);
       // }
}

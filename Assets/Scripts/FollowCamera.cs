using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
   public Transform target;

   private float offsetX;

   void Start()
   {
      if (target == null)
         return;
      
      offsetX = transform.position.x - target.position.x;
   }

   void Update()
   {
      if (target == null)
         return;
   
      // 카메라의 현재 위치를 받아와서, x 값을 카메라 - player 사이 위치만큼 계속해서 증가 후 현재 위치에 넣어줌
      // == 카메라가 게임 시작 시 카메라 - Player 위치값만큼만 계속해서 이동함. Player의 속도가 달라지면 수정해야 함.
      Vector3 pos = transform.position;
      pos.x = target.position.x + offsetX;
      transform.position = pos;
   }
}

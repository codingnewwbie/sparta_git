using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;
    void Start()
    {
        //Obstacle이라는 스크립트가 포함된 오브젝트 개수만큼 List 생성.
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); // 가볍지 않으니 스타트나 어웨이크에서 한번만 동작하도록
        // 마지막 위치는 첫번째 장애물부터 시작. 계속해서 +
        obstacleLastPosition = obstacles[0].transform.position;
        // 장애물 카운트 = obstacles List의 길이
        obstacleCount = obstacles.Length;

        // SetRandomPlace로 마지막 위치와 개수를 넣어 랜덤한 장소에 배치
        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    // 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered" + collision.name);

        // 충돌하는 장애물을 받아와서
        Obstacle obstacle = collision.GetComponent<Obstacle>();

        // 충돌할 때마다 해당 장애물의 위치를 재지정(이전 마지막 위치를 이용, + 해서 반환)
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
        
        // 배경과 충돌하면 배경의 위치를 재지정
        if (collision.CompareTag("Background"))
        {
            // 충돌한 배경의 size.x를 구하고
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            
            // 배경의 localPosition을 구해서
            Vector3 bgPosition = collision.transform.position;

            // 현재 위치에서 배경의 size * 배경오브젝트 수 만큼 x 값 바꾸고
            bgPosition.x += widthOfBgObject * numBgCount;
            
            // 그 x값대로 현재 오브젝트의 localPosition 재지정.
            collision.transform.position = bgPosition;
        }
    }
}

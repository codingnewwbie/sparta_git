using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    GameManager gameManager;
    
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int ObstacleCount)
    {
        //장애물 사이 hole의 Size는 최소-최대 사이 중 랜덤으로.
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        
        // 장애물 사이 크기를 나눠
        float halfHoleSize = holeSize / 2;

        //천장에 있는 오브젝트는 위로 당기고 바텀에 있는 오브젝트는 아래로 내림( = 구멍 사이즈에 맞춰서)
        // ==> 추가 설명 : 하나의 Obstacle 안의 topObject와 bottomObject의 위치를 조절.
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);
        
        // placePosition는 마지막 장애물 위치에서 x축으로 widthPadding를 더하고 y축으로는 -1f ~ 1f 사이로 만듬.
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);
        
        // 장애물 위치를 만든 위치로 넣고 리턴. 리턴하는 이유 = BgLooper에서 이용하기 위해(장애물 반복 생성 시 마지막 위치를 이용)
        // ==> 하나의 Obstacle의 위치를 조절하여, 같은 HoleSize가 상중하로 나오도록 조절.
        transform.position = placePosition;

        return placePosition;

    }

    // 장애물을 빠져나갈 때 AddScore 실행되도록
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            gameManager.AddScore(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObstacle : MonoBehaviour
{
    public float moveSpeed = 5f;        // 장애물 이동 속도
    public Sprite[] images;             // 장애물 스프라이트들

    private SpriteRenderer spriteRender;
    private float destroyX = -15f;      // 이 위치보다 왼쪽으로 가면 삭제

    void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        
        if (spriteRender == null)       //디버깅용
        {
            Debug.LogError("SpriteRenderer가 없습니다");
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }

    // 이미지 설정 함수
    public void Init(int type)
    {
        if (type >= images.Length)
            return;

        spriteRender.sprite = images[type];
    }
}

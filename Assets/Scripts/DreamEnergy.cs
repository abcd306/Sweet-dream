using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamEnergy : MonoBehaviour
{
    public static DreamEnergy instance;

    public float moveSpeed = 5f;        // 장애물 이동 속도
    private float destroyX = -15f;      // 이 위치보다 왼쪽으로 가면 삭제

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    //void Start()            시작할 때 쉴드 비활성화
    //{
    //    if (shieldObject != null)
    //        shieldObject.SetActive(false);
    //}

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.instance.AddCoin();
            Destroy(gameObject);
        }
    }
}

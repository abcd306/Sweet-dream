using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamEnergy : MonoBehaviour
{
    public static DreamEnergy instance;

    public float moveSpeed = 5f;        // ��ֹ� �̵� �ӵ�
    private float destroyX = -15f;      // �� ��ġ���� �������� ���� ����

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    //void Start()            ������ �� ���� ��Ȱ��ȭ
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

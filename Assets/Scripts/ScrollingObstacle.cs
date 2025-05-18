using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObstacle : MonoBehaviour
{
    public float moveSpeed = 5f;        // ��ֹ� �̵� �ӵ�
    public Sprite[] images;             // ��ֹ� ��������Ʈ��

    private SpriteRenderer spriteRender;
    private float destroyX = -15f;      // �� ��ġ���� �������� ���� ����

    void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        
        if (spriteRender == null)       //������
        {
            Debug.LogError("SpriteRenderer�� �����ϴ�");
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

    // �̹��� ���� �Լ�
    public void Init(int type)
    {
        if (type >= images.Length)
            return;

        spriteRender.sprite = images[type];
    }
}

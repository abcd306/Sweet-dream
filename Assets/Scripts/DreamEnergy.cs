using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamEnergy : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float destroyX = -15f;

    public GameObject CoinEffectPrefab; // ��ƼŬ ������ �����

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)    // ��ƼŬ ������ �����
    {
        if (other.CompareTag("Player"))
        {
            GameObject effect = Instantiate(CoinEffectPrefab, transform.position, Quaternion.identity);

            // ��ƼŬ �ٷ� ���
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null) ps.Play();

            Destroy(gameObject); // ���� �ı�
        }
    }
}

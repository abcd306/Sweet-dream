using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamEnergy : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float destroyX = -15f;

    public GameObject CoinEffectPrefab; // 파티클 프리팹 실험용

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)    // 파티클 프리팹 실험용
    {
        if (other.CompareTag("Player"))
        {
            GameObject effect = Instantiate(CoinEffectPrefab, transform.position, Quaternion.identity);

            // 파티클 바로 재생
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null) ps.Play();

            Destroy(gameObject); // 코인 파괴
        }
    }
}

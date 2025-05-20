using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private float invincibleTime = 1.5f;

    private int currentLives;
    private bool isInvincible;

    [SerializeField] private GameObject healingEffectPrefab;
    [SerializeField] private Transform healingEffectPoint;

    private void Start()
    {
        currentLives = maxLives;
        UIManager.instance.UpdateLivesUI(currentLives);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TakeDamage();
        }
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    void TakeDamage()
    {
        if (isInvincible) return;

        currentLives--;
        UIManager.instance.UpdateLivesUI(currentLives);
        RestoreFullHP();

        if (currentLives <= 0)
        {
            Die();
        }
        else
        {
            isInvincible = true;
            Invoke("StopInvincible", invincibleTime);
        }
    }

    void StopInvincible()
    {
        isInvincible = false;
    }

    void Die()
    {
        Debug.Log("Game Over");
    }

    //Ctrl + K → Ctrl + C(주석 처리)
    //Ctrl + K → Ctrl + U(주석 해제)
    public void RestoreFullHP()
    {
        currentLives = maxLives;
        UIManager.instance.UpdateLivesUI(currentLives);
        PlayHealingEffect();
    }
    void PlayHealingEffect()
    {
        if (healingEffectPrefab != null && healingEffectPoint != null)
        {
            GameObject effect = Instantiate(healingEffectPrefab, healingEffectPoint.position, Quaternion.identity);
            Destroy(effect, 2f); // 2초 후 자동 삭제
        }
    }
}
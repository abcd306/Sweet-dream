using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private float invincibleTime = 1.5f;

    private int currentLives;
    private bool isInvincible;

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
}
//public void RestoreFullHP()
//currentLives = maxLives;
//UIManager.instance.UpdateLivesUI(currentLives);

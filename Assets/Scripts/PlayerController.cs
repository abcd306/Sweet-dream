using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private int maxLives = 3;
    private int currentLives;
    private float invincibleTime = 1.5f;
    private bool isInvincible;

    //public GameObject shieldObject;
    //public float shieldDuration = 2f;
    //[HideInInspector] public bool isShieldActive = false;

    SpriteRenderer spr;
    Color halfA = new Color(1, 1, 1, 0.5f);
    Color fullA = new Color(1, 1, 1, 1);

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        RestoreFullHP();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        ActivateShield();
    //    }
    //}

    public void TakeDamage()
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
            StartCoroutine(AlphaBlink());
            Invoke("StopInvincible", invincibleTime);
        }
    }

    // ��� ó���� �޼��� (Die�� ���ĵ���, ���� ����)
    public void ForceDie()
    {
        currentLives = 0;
        UIManager.instance.UpdateLivesUI(currentLives);
        Die();
    }

    public void RestoreFullHP()    // é�� �Ѿ �� ������ �ʱ�ȭ
    {
        currentLives = maxLives;
        UIManager.instance.UpdateLivesUI(currentLives);
    }

    void Die()
    {
        Debug.Log("Game Over");
    }

    void StopInvincible()
    {
        isInvincible = false;
        spr.color = fullA;
    }

    IEnumerator AlphaBlink()        // �浹 �� �÷��̾� ������
    {
        while (isInvincible)
        {
            spr.color = halfA;
            yield return new WaitForSeconds(0.2f);
            spr.color = fullA;
            yield return new WaitForSeconds(0.2f);
        }
    }

    //Ctrl + K �� Ctrl + C(�ּ� ó��)
    //Ctrl + K �� Ctrl + U(�ּ� ����)

    //public bool UseShield()
    //{
    //    if (coinCount < 1)
    //        return false;

    //    coinCount--;
    //    UIManager.instance.UpdateCoinUI(coinCount);

    //    return true;
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Lightning"))
    //    {
    //        if (DreamEnergy.instance != null && isShieldActive)
    //        {
    //            Destroy(other.gameObject);  // ���� ������ ������ �� ����
    //        }
    //        else
    //        {
    //            TakeDamage();               // ���� ������ ������
    //            Destroy(other.gameObject);
    //        }
    //    }
    //}

//    public void ActivateShield()
//    {
//        if (isShieldActive) return;

//        bool success = UseShield();
//        if (!success) return;

//        isShieldActive = true;
//        StartCoroutine(ShieldRoutine());
//    }

//    private IEnumerator ShieldRoutine()
//    {
//        shieldObject.SetActive(true);
//        yield return new WaitForSeconds(shieldDuration);
//        shieldObject.SetActive(false);
//        isShieldActive = false;
//    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int collectedCoins = 0;
    public int requiredCoins = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()       // ����� �ڵ� ( �����̽��ٷ� play/pause )
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale > 0f)
            {
                Time.timeScale = 0f; // �Ͻ�����
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    public void SetRequiredCoins(int amount)
    {
        // é�ͺ��� �ʿ��� ���� �� ����
        requiredCoins = amount;
        UpdateCoinUI();
    }

    public void AddCoin()
    {
        collectedCoins++;
        UpdateCoinUI();
    }

    public void ResetCoins()
    {
        // ���� ���� 0���� �ʱ�ȭ
        collectedCoins = 0;
        UpdateCoinUI();
    }

    public bool HasEnoughCoins() => collectedCoins >= requiredCoins;

    public int GetCollectedCoins() => collectedCoins;
    public int GetRequiredCoins() => requiredCoins;

    private void UpdateCoinUI()
    {
        // "���� / �ʿ�" ���·� ���� ǥ��
        UIManager.instance.UpdateCoinUI(collectedCoins, requiredCoins);
    }
}

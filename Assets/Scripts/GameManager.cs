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

    void Update()       // 실험용 코드 ( 스페이스바로 play/pause )
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale > 0f)
            {
                Time.timeScale = 0f; // 일시정지
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    public void SetRequiredCoins(int amount)
    {
        // 챕터별로 필요한 코인 수 설정
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
        // 코인 수를 0으로 초기화
        collectedCoins = 0;
        UpdateCoinUI();
    }

    public bool HasEnoughCoins() => collectedCoins >= requiredCoins;

    public int GetCollectedCoins() => collectedCoins;
    public int GetRequiredCoins() => requiredCoins;

    private void UpdateCoinUI()
    {
        // "현재 / 필요" 형태로 코인 표시
        UIManager.instance.UpdateCoinUI(collectedCoins, requiredCoins);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image[] heartImages;
    public Image coinIcon;                 // 드림에너지 코인 이미지
    public TextMeshProUGUI coinText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // 씬 전환 시 파괴되지 않도록 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateLivesUI(heartImages.Length);
        HideCoinUI();
    }

    public void UpdateLivesUI(int lives)
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].gameObject.SetActive(i < lives);
        }
    }

    public void UpdateCoinUI(int collected, int required)
    {
        bool showCoinUI = required > 0;
        coinIcon.gameObject.SetActive(showCoinUI);
        coinText.gameObject.SetActive(showCoinUI);

        if (showCoinUI)
        {
            coinText.text = $"{collected} / {required}";
        }
    }

    public void HideCoinUI()
    {
        coinIcon.gameObject.SetActive(false);
        coinText.gameObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private int chapter;
    private bool lightningTriggered;

    private void Start()
    {
        chapter = GetChapter();
        InitChapter();
    }

    private void Update()
    {
        HandleTestInput();

        if (chapter >= 3 && !lightningTriggered && !GameManager.instance.HasEnoughCoins())
        {
            LightningManager.instance.TriggerLightning();
            lightningTriggered = true;
        }
    }

    private int GetChapter()
    {
        string name = SceneManager.GetActiveScene().name;

        if (name.Contains("Chapter1")) return 1;
        if (name.Contains("Chapter2")) return 2;
        if (name.Contains("Chapter3")) return 3;
        if (name.Contains("Chapter4")) return 4;

        return 0;
    }

    private void InitChapter()
    {
        int coins = 0;

        if (chapter == 3) coins = 2;
        else if (chapter == 4) coins = 3;

        GameManager.instance.SetRequiredCoins(coins);
        GameManager.instance.ResetCoins();

        if (coins == 0)
            UIManager.instance.HideCoinUI();

        PlayerController.instance.RestoreFullHP();
        lightningTriggered = false;
    }

    private void HandleTestInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextChapter();
        }
    }

    private void NextChapter()
    {
        chapter++;

        if (chapter > 4)
        {
            Debug.Log("게임 클리어!");
            SceneManager.LoadScene("Ending");
            return;
        }

        SceneManager.LoadScene($"Chapter{chapter}");
    }
}

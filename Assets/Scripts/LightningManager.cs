using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningManager : MonoBehaviour
{

    public static LightningManager instance;

    public GameObject lightning1Prefab;     // 쉴드 없는 거
    public GameObject lightning2Prefab;     // 쉴드 있는 거
    public Transform spawnPoint;
    public float moveSpeed = 5f;
    private float destroyY = -15f;

    private GameObject activeLightning;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void TriggerLightning()      // 수정하기
    {
        {
            if (PlayerController.instance == null || GameManager.instance == null)
            {
                Debug.LogWarning("PlayerController or GameManager not found");
                return;
            }

            // 이미 번개가 있으면 삭제 (중복 방지)
            if (activeLightning != null)
            {
                Destroy(activeLightning);
                activeLightning = null;
            }

            int coin = GameManager.instance.GetCollectedCoins();
            int required = GameManager.instance.requiredCoins;

            bool survived = coin >= required;
            GameObject prefabToUse = survived ? lightning2Prefab : lightning1Prefab;

            if (prefabToUse != null && spawnPoint != null)
            {
                activeLightning = Instantiate(prefabToUse, spawnPoint.position, Quaternion.identity);
            }

            if (!survived)
            {
                PlayerController.instance.ForceDie();
            }
        }
    }

    private void Update()
    {
        if (activeLightning != null)
        {
            activeLightning.transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

            if (activeLightning.transform.position.y <= destroyY)
            {
                Destroy(activeLightning);
                activeLightning = null;
            }
        }
    }
}

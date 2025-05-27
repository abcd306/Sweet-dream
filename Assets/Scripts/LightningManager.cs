using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningManager : MonoBehaviour
{

    public static LightningManager instance;

    public GameObject lightning1Prefab;     // ���� ���� ��
    public GameObject lightning2Prefab;     // ���� �ִ� ��
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

    public void TriggerLightning()      // �����ϱ�
    {
        {
            if (PlayerController.instance == null || GameManager.instance == null)
            {
                Debug.LogWarning("PlayerController or GameManager not found");
                return;
            }

            // �̹� ������ ������ ���� (�ߺ� ����)
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

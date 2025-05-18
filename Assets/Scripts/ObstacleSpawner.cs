using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObstaclePattern
{
    public float spawnTime;   // ���� ��ֹ� �������� ��� �ð�
    public int type;          // 0: �Ʒ�, 1: ��
    public int imageType;     // ��������Ʈ �ε���

    public ObstaclePattern(float spawnTime, int type, int imageType)
    {
        this.spawnTime = spawnTime;
        this.type = type;
        this.imageType = imageType;
    }
}

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;     // 0: �Ʒ�, 1: ��
    public Transform[] spawnPoints;          // 0: �Ʒ�, 1: ��
    public ObstaclePattern[] patterns;       // ��ֹ� ���� �迭
    public float destroyX = -15f;            // �̺��� �����̸� �ı�

    private int currentIndex = 0;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (currentIndex < patterns.Length)
        {
            ObstaclePattern pattern = patterns[currentIndex];
            yield return new WaitForSeconds(pattern.spawnTime);

            if (pattern.type == 0 || pattern.type == 1)
            {
                SpawnObstacle(pattern.type, pattern.imageType);
            }
            else
            {
                Debug.LogWarning($"�������� �ʴ� Ÿ���Դϴ�: {pattern.type}");
            }

            currentIndex++;
        }
    }

    void SpawnObstacle(int type, int imageType)
    {
        GameObject obj = Instantiate(obstaclePrefabs[type], spawnPoints[type].position, Quaternion.identity);
        ScrollingObstacle obs = obj.GetComponent<ScrollingObstacle>();
        obs.Init(imageType);
    }
}
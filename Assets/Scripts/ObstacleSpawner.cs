using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObstaclePattern
{
    public float spawnTime;   // 다음 장애물 생성까지 대기 시간
    public int type;          // 0: 아래, 1: 위
    public int imageType;     // 스프라이트 인덱스

    public ObstaclePattern(float spawnTime, int type, int imageType)
    {
        this.spawnTime = spawnTime;
        this.type = type;
        this.imageType = imageType;
    }
}

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;     // 0: 아래, 1: 위
    public Transform[] spawnPoints;          // 0: 아래, 1: 위
    public ObstaclePattern[] patterns;       // 장애물 패턴 배열
    public float destroyX = -15f;            // 이보다 왼쪽이면 파괴

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
                Debug.LogWarning($"지원되지 않는 타입입니다: {pattern.type}");
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
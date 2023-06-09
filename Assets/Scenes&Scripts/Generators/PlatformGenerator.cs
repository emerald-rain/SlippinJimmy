using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject player;

    [System.Serializable]
    public struct PlatformInfo
    {
        public GameObject prefab;
        public float chance;
    }

    [System.Serializable]
    public struct PlatformDistanceChange
    {
        public float yPosition;
        public float newPlatformDistance;
    }

    public List<PlatformInfo> platforms;
    public List<PlatformDistanceChange> platformDistanceChanges;
    public int poolSize = 50;
    public float levelWidth = 5f;

    private Queue<GameObject> platformPool;
    private List<GameObject> activePlatforms;
    private float platformDistance = 1f;
    private float minYOffset = 30f;
    private float maxYOffset = 30f;
    private float initialPlatformY = -10f;
    private float lastPlatformY;

    void Start()
    {
        lastPlatformY = initialPlatformY;
        CreatePlatformPool();
        FillPlatformPool();
        activePlatforms = new List<GameObject>();
    }

    void Update()
    {
        float playerY = player.transform.position.y;

        // Update platformDistance based on Y position changes
        foreach (PlatformDistanceChange distanceChange in platformDistanceChanges)
        {
            if (playerY >= distanceChange.yPosition)
            {
                platformDistance = distanceChange.newPlatformDistance;
            }
        }

        // Generate platforms above 'Y character plus 50'
        while (lastPlatformY < playerY + maxYOffset)
        {
            GeneratePlatform();
        }

        // Remove platforms below 'Y character minus 20'
        for (int i = 0; i < activePlatforms.Count; i++)
        {
            if (activePlatforms[i].transform.position.y < playerY - minYOffset)
            {
                RemovePlatform(i);
            }
        }
    }

    void CreatePlatformPool()
    {
        platformPool = new Queue<GameObject>();
    }

    void FillPlatformPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject platform = Instantiate(ChoosePlatform(), Vector3.zero, Quaternion.identity);
            platform.SetActive(false);
            platformPool.Enqueue(platform);
        }
    }

    void GeneratePlatform()
    {
        float x = Random.Range(-levelWidth / 2f, levelWidth / 2f);
        float y = lastPlatformY + platformDistance;
        Vector3 position = new Vector3(x, y, 0f);

        GameObject platform = platformPool.Dequeue();
        platform.transform.position = position;
        platform.SetActive(true);

        lastPlatformY = y;
        activePlatforms.Add(platform);
    }

    void RemovePlatform(int index)
    {
        GameObject platform = activePlatforms[index];
        platform.SetActive(false);
        platformPool.Enqueue(platform);
        activePlatforms.RemoveAt(index);
    }

    GameObject ChoosePlatform()
    {
        float totalChance = 0f;
        foreach (PlatformInfo platform in platforms)
        {
            totalChance += platform.chance;
        }

        float randomValue = Random.Range(0f, totalChance);
        float currentChance = 0f;

        foreach (PlatformInfo platform in platforms)
        {
            currentChance += platform.chance;
            if (randomValue <= currentChance)
            {
                return platform.prefab;
            }
        }

        return platforms[0].prefab;
    }
}

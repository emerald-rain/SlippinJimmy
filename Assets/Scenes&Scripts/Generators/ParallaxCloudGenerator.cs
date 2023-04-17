using System.Collections.Generic;
using UnityEngine;

public class ParallaxCloudGenerator : MonoBehaviour
{
    [System.Serializable]
    public struct CloudInfo
    {
        public GameObject prefab;
        public float chance;
    }

    [System.Serializable]
    public struct ParallaxLayer
    {
        public float speed;
    }

    public List<CloudInfo> clouds;
    public List<ParallaxLayer> parallaxLayers;
    public int poolSize = 50;
    public float minYOffset = 20f;
    public float maxYOffset = 50f;
    public float levelWidth = 5f;
    public float cloudDistance = 5f;

    private Queue<GameObject> cloudPool;
    private float lastCloudY;
    private int cloudDirection;

    void Start()
    {
        lastCloudY = transform.position.y;
        cloudDirection = Random.Range(0, 2) * 2 - 1; // -1 or 1
        CreateCloudPool();
        FillCloudPool();
    }

    void Update()
    {
        float cameraY = Camera.main.transform.position.y;
        while (cloudPool.Peek().transform.position.y < cameraY - minYOffset)
        {
            RemoveCloud();
        }

        while (lastCloudY < cameraY + maxYOffset)
        {
            GenerateCloud();
        }
    }

    void CreateCloudPool()
    {
        cloudPool = new Queue<GameObject>();
    }

    void FillCloudPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject cloud = Instantiate(ChooseCloud(), Vector3.zero, Quaternion.identity);
            cloud.SetActive(false);
            cloudPool.Enqueue(cloud);
        }
    }

    void GenerateCloud()
    {
        float x = Random.Range(-levelWidth / 2f, levelWidth / 2f);
        float y = lastCloudY + cloudDistance;
        Vector3 position = new Vector3(x, y, 0f);

        GameObject cloud = cloudPool.Dequeue();
        cloud.transform.position = position;
        cloud.SetActive(true);

        int layer = Random.Range(0, parallaxLayers.Count);
        cloud.transform.SetParent(transform);
        cloud.GetComponent<FloatingCloud>().Initialize(layer, parallaxLayers[layer].speed * cloudDirection);

        lastCloudY = y;
        cloudPool.Enqueue(cloud);
    }

    void RemoveCloud()
    {
        GameObject cloud = cloudPool.Dequeue();
        cloud.SetActive(false);
        cloudPool.Enqueue(cloud);
    }

    GameObject ChooseCloud()
    {
        float totalChance = 0f;
        foreach (CloudInfo cloud in clouds)
        {
            totalChance += cloud.chance;
        }

        float randomValue = Random.Range(0f, totalChance);
        float currentChance = 0f;

        foreach (CloudInfo cloud in clouds)
        {
            currentChance += cloud.chance;
            if (randomValue <= currentChance)
            {
                return cloud.prefab;
            }
        }

        return clouds[0].prefab;
    }
}
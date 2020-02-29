using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformType
{
    NONE,
    LARGE,
    MEDIUM,
    SMALL,
    TINY,
}

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public PlatformType tag;
        public GameObject platform;
        public int size;
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> platforms;
    public Dictionary<PlatformType, Queue<GameObject>> platformDictionary;

    [SerializeField] private GameObject gameManager;

    void Start()
    {
        platformDictionary = new Dictionary<PlatformType, Queue<GameObject>>();

        foreach (Pool platform in platforms)
        {
            Queue<GameObject> platformPool = new Queue<GameObject>();

            for (int i = 0; i < platform.size; i++)
            {
                GameObject pForm = Instantiate(platform.platform, gameManager.transform);
                pForm.SetActive(false);
                platformPool.Enqueue(pForm);
            }

            platformDictionary.Add(platform.tag, platformPool);
        }
    }

    public GameObject PlatformToSpawn(PlatformType tag, Vector3 position, Quaternion rotation, int spawnNumber, bool spawnCoin)
    {
        if (!platformDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " does not exist");
            return null;
        }
        GameObject platformToSpawn = platformDictionary[tag].Dequeue();

        platformToSpawn.SetActive(true);
        platformToSpawn.transform.position = position;
        platformToSpawn.transform.rotation = rotation;
        platformToSpawn.GetComponent<Platform>().platformNumber = spawnNumber;

        if (spawnCoin)
        {
            platformToSpawn.GetComponent<Platform>().EnableCoin();
        }

        return platformToSpawn;
    }

    public void EnqueuePlatform(PlatformType tag, GameObject platformToQueue)
    {
        platformDictionary[tag].Enqueue(platformToQueue);
    }
}

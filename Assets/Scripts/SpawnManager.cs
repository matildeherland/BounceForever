using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> platforms;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Vector2 spawnRotation;
    [SerializeField] private float chanceToSpawnCoin;

    private int spawnHeight = 3;
    private int spawnCounter = 1;
    private int coinOffset = 2;

    //private string[] platformTags = new string[4] {"Large", "Medium", "Small", "Tiny" };


    // Start is called before the first frame update
    void Start()
    {
        InstantiatePlatforms(10);
    }

    // Update is called once per frame
    void Update()
    {        

    }

    public void InstantiatePlatforms(int platformsToSpawn)
    {        
        for (int i = 0; i < platformsToSpawn; i++)
        {
            List<PlatformType> eligibleTypes = new List<PlatformType>();
            for (int j = 1; j < System.Enum.GetNames(typeof(PlatformType)).Length; j++)
            {
                PlatformType pt = (PlatformType)j;
                if (ObjectPooler.Instance.platformDictionary.ContainsKey(pt) && ObjectPooler.Instance.platformDictionary[pt].Count > 0)
                {
                    eligibleTypes.Add(pt);
                }
            }

            PlatformType randomPlatform = eligibleTypes[Random.Range(0, eligibleTypes.Count)];
            float spawnCoinRandom = Random.Range(0.0f, 1.0f);
            bool spawnCoin = false;
            if (spawnCoinRandom < chanceToSpawnCoin)
            {
                spawnCoin = true;
            }
            ObjectPooler.Instance.PlatformToSpawn(randomPlatform, new Vector3(0, spawnHeight * spawnCounter, 0), Quaternion.Euler(new Vector3(0, Random.Range(spawnRotation.x, spawnRotation.y), 0)), spawnCounter, spawnCoin);

            spawnCounter++;
        }
    }
}

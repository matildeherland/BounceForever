using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnTrigger : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            PlatformType pt = other.gameObject.GetComponent<Platform>().platformType;
            if (pt == PlatformType.NONE)
            {
                Destroy(other.gameObject);
            }
            else
            {
                ObjectPooler.Instance.EnqueuePlatform(pt, other.gameObject);
                other.GetComponent<Collider>().isTrigger = true;
                other.gameObject.SetActive(false);
            }

            spawnManager.InstantiatePlatforms(1);
        }
    }
}

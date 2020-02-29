using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformType platformType;
    public int platformNumber;

    [SerializeField] GameObject coinPrefab;

    public void EnableCoin()
    {
        coinPrefab.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{

    [SerializeField] GameObject[] gameObjectsToPool;
    [SerializeField] int numbersToPool;

    void Awake()
    {
        GameObject gO;
        for (int i = 0; i < numbersToPool; i++)
        {
            gO = Instantiate(gameObjectsToPool[Random.Range(0, gameObjectsToPool.Length)], transform);
            gO.SetActive(false);
        }
    }
}

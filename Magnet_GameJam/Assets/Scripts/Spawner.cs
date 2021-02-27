using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Spawner : MonoBehaviour
{
    [SerializeField] bool isSpawning = true;
    [SerializeField][Range(0.1f, 50f)] float spawningRateMin = 5f;
    [SerializeField][Range(0.1f, 50f)] float spawningRateMax = 5f;
    [SerializeField] float levelUpRate = 0.5f;
    List<GameObject> items = new List<GameObject>();

    float timer;
    int index;
    bool isObstructed;

    void Start()
    {
        foreach (Transform item in transform)
        {
            items.Add(item.gameObject);
        }
    }

    void Update()
    {
        if (isSpawning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Spawn();
                timer = Random.Range(spawningRateMin, spawningRateMax);
            }
        }
    }

    void Spawn()
    {
        if (!isObstructed)
        {
            if(spawningRateMax - levelUpRate > spawningRateMin * 2) spawningRateMax -= levelUpRate;
            items[index].transform.position = transform.position;
            items[index].SetActive(true);
            index++;
            if (index >= items.Count) index = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        isObstructed = true;
    }

    void OnTriggerExit(Collider other)
    {
        isObstructed = false;
    }

}

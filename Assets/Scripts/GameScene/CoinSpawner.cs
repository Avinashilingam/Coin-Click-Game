using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public RectTransform spawnArea;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 2f;

    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnCoin();
            timer = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    void SpawnCoin()
    {
        // Get the width and height of the spawn area
        float width = spawnArea.rect.width;
        float height = spawnArea.rect.height;

        // Calculate a random position inside the RectTransform
        float x = Random.Range(-width / 2f, width / 2f);
        float y = Random.Range(-height / 2f, height / 2f);

        Vector2 spawnPos = new Vector2(x, y);

        // Instantiate coin inside the spawnArea
        GameObject coin = Instantiate(coinPrefab, spawnArea);
        coin.GetComponent<RectTransform>().anchoredPosition = spawnPos;
    }
}

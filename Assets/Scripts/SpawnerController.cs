using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] public GameObject[] enemyPrefab;
    [SerializeField] public float startDelay = 2;
    [SerializeField] public float spawnInterval;
    [SerializeField] public float dafaultSpawnInterval = 1.5f;

    [SerializeField] float _counter = 0f;

    [SerializeField] enum Difficulties { Easy = 1, Normal , Hard}
    [SerializeField] private Difficulties difficulty;

    void Start()
    {

        switch (difficulty)
        {
            case Difficulties.Easy:
                //Debug.Log("EASY MODE");

                spawnInterval = dafaultSpawnInterval + 3f;
                break;
            case Difficulties.Normal:
                //Debug.Log("NORMAL MODE");
                spawnInterval = dafaultSpawnInterval;
                break;
            case Difficulties.Hard:
                //Debug.Log("HARD MODE");
                spawnInterval = dafaultSpawnInterval - 1f;
                break;
            default:
                Debug.Log("ERROR THIS IS NOT A GAME MODE AVAILABLE");
                break;
        }
    }

    [SerializeField]
    private void Update()
    {
        _counter+= Time.deltaTime;

        if (_counter >= spawnInterval)
        {
            SpawnEnemy();
            _counter = 0f;
        }
    }

    [SerializeField]
    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[enemyIndex], transform.position, enemyPrefab[enemyIndex].transform.rotation);
    }

}

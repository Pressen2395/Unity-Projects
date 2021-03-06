﻿/*
*Copyright (c) Pressen
*/

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private float _spawnTimer = 5f;
    private bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn gameobjects every 5 seconds.
    //create a coroutine of type IEnumerator -- Yield events
    //while loop

    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 8, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_spawnTimer);
        }
    }
    public void OnPlayerDeath()
	{
        _stopSpawning = true;
	}

    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 8, 0);
            int _random = Random.Range(0, 3);
            Instantiate(powerups[_random], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(10, 20));
        }
    }
	
}

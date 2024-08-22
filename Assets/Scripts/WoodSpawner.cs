using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class WoodSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPooling _objectPooling;
    private float _interval;
    private bool isRunning = true;

    private void Start()
    {
        StartCoroutine(CallSpawn());
    }

    IEnumerator CallSpawn()
    {
        while (isRunning)
        {
            yield return new WaitForSecondsRealtime(_interval);
            SpawnWood();
            _interval = Random.Range(1,7);
        }
    }

    void SpawnWood()
    {
        float X = Random.Range(-3.5f,8);
        float Y = Random.Range(0.3f,3.2f);
        Vector3 SpawnPos = new Vector3(X, Y, 0);
        _objectPooling.SpawnObject(SpawnPos);
    }
}

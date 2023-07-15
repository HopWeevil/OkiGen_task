using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _foodTemplates;
    [SerializeField] private float _spawnDelay;

    private bool _canSpawn;

    private void Start()
    {
        _canSpawn = false;
    }

    public void StartSpawning()
    {
        _canSpawn = true;
    }

    private void Update()
    {
        SpawnRandomFood();
    }

    private void SpawnRandomFood()
    {
        if (_canSpawn)
        {
            int foodIndex = Random.Range(0, _foodTemplates.Length);
            Instantiate(_foodTemplates[foodIndex], transform.position, Quaternion.identity, transform);
            StartCoroutine(SpawnDelay());
        }
    }

    private IEnumerator SpawnDelay()
    {
        _canSpawn = false;
        yield return new WaitForSeconds(_spawnDelay);
        _canSpawn = true;
    }
}
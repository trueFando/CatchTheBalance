using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _miniballPrefab;
    [SerializeField] private float _delay;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    public void StartSpawning()
    {
        StartCoroutine(SpawningRoutine());
    }
    
    public void StopSpawning()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawningRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        float x = Random.Range(_minX, _maxX);
        Vector3 position = new Vector3(x, transform.position.y, transform.position.z);
        Instantiate(_miniballPrefab, position, Quaternion.identity);
    }
}

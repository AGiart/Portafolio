using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] spawnPrefabs;

    [SerializeField]
    float spawnTime = 1.5F;

    [SerializeField]
    Transform target;

    [SerializeField]
    float minDistanceToTarget = 5.0F;

    [SerializeField]
    float maxLifeTime = 30.0F;

    float _currentTime;
    float _maxDistanceToTarget;
    private void Start()
    {
        _maxDistanceToTarget = minDistanceToTarget + 10;
        _currentTime = spawnTime;
    }
    private void Update()
    {
        _currentTime -= Time.deltaTime;
        if (_currentTime <= 0.0F)
        {
            SpawnObject();
            _currentTime = spawnTime;
        }

    }
    private void SpawnObject()
    {
        int spawnIndex = Random.Range(0, spawnPrefabs.Length);
        GameObject spawnPrefab = spawnPrefabs[spawnIndex];

        Vector3 position = target.position;
        while (Vector2.Distance(target.position, position) < minDistanceToTarget)
        {
            float angle = Random.Range(0.0F, 360.0F);
            float distance = Random.Range(minDistanceToTarget, _maxDistanceToTarget);
            position = distance * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }





        GameObject spawnObject = Instantiate(spawnPrefab, position, Quaternion.identity);
        FloatDirectionController controller = spawnObject.GetComponent<FloatDirectionController>();
        controller.SetTarget(target);
        Destroy(spawnObject, maxLifeTime);
    }
}

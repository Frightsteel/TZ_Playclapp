using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _poolSize;
    [SerializeField] private bool _autoExpand;

    private float _speed = 4f;
    private float _distance = 10f;
    private float _spawnTime = 2f;

    public PoolMono<Cube> ProjectilePool { get; private set; }

    private void Start()
    {
        ProjectilePool = new PoolMono<Cube>(_cubePrefab, _poolSize, transform);
        ProjectilePool.AutoExpand = _autoExpand;

        StartCoroutine(Spawn());
    }

    public void SetSpeed(string value)
    {
        _speed = float.Parse(value);
    }

    public void SetDistance(string value)
    {
        _distance = float.Parse(value);
    }

    public void SetSpawnTime(string value)
    {
        _spawnTime = float.Parse(value);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            Cube currentCube = ProjectilePool.GetFreeElement();
            currentCube.SetSpeed(_speed);
            currentCube.SetDistance(_distance);
        }
    }
}

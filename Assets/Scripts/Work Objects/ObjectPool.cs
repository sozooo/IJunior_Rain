using System;
using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Spawnable _spawnablePrefab;

    private Queue<Spawnable> _spawnables;

    public event Action ObjectTaken;

    private void Awake()
    {
        _spawnables = new Queue<Spawnable>();
    }

    public void Add(Spawnable cube)
    {
        cube.gameObject.SetActive(false);
        _spawnables.Enqueue(cube);
    }

    public Spawnable Take()
    {
        Spawnable cube;

        if(_spawnables.Count == 0)
            cube = Instantiate(_spawnablePrefab);
        else
            cube = _spawnables.Dequeue();

        ObjectTaken?.Invoke();

        return cube;
    }
}

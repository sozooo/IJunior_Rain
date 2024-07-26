using System;
using UnityEngine;
using System.Collections.Generic;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour, ISpawnable<T>
{
    [SerializeField] private T _spawnablePrefab;

    private Queue<T> _spawnables;

    public event Action ObjectTaken;

    private void Awake()
    {
        _spawnables = new Queue<T>();
    }

    public void Add(T spawnable)
    {
        spawnable.gameObject.SetActive(false);
        _spawnables.Enqueue(spawnable);
    }

    public T Give()
    {
        T spawnable;

        if(_spawnables.Count == 0)
            spawnable = Instantiate(_spawnablePrefab);
        else
            spawnable = _spawnables.Dequeue();

        ObjectTaken?.Invoke();

        return spawnable;
    }
}

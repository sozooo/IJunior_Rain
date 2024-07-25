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

    public void Add(Spawnable spawnable)
    {
        spawnable.gameObject.SetActive(false);
        _spawnables.Enqueue(spawnable);
    }

    public Spawnable Give()
    {
        Spawnable spawnable;

        if(_spawnables.Count == 0)
            spawnable = Instantiate(_spawnablePrefab);
        else
            spawnable = _spawnables.Dequeue();

        ObjectTaken?.Invoke();

        return spawnable;
    }
}

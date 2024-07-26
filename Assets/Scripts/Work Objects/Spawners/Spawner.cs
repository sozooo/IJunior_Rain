using System;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, ISpawnable<T>
{
    [SerializeField]protected ObjectPool<T> Pool;
    [SerializeField] protected Color ObjectColor;

    public event Action ObjectSpawned;
    public event Action ObjectDespawned;

    public virtual T Spawn()
    {
        T spawnable = Pool.Give();

        spawnable.Despawn += Despawn;
        spawnable.gameObject.SetActive(true);

        spawnable.transform.position = transform.position;

        ObjectSpawned?.Invoke();

        return spawnable;
    }

    protected virtual void Despawn(T spawnable)
    {
        spawnable.Despawn -= Despawn;

        Pool.Add(spawnable);

        ObjectDespawned?.Invoke();
    }
}

using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected Color ObjectColor;

    protected ObjectPool Pool;

    public event Action ObjectSpawned;
    public event Action ObjectDespawned;

    protected void Awake()
    {
        Pool = GetComponent<ObjectPool>();
    }

    public virtual Spawnable Spawn()
    {
        Spawnable spawnable = Pool.Take();

        spawnable.Renderer.material.color = ObjectColor;
        spawnable.Despawn += Despawn;
        spawnable.gameObject.SetActive(true);

        spawnable.transform.position = transform.position;

        ObjectSpawned?.Invoke();

        return spawnable;
    }

    protected void Despawn(Spawnable spawnable)
    {
        spawnable.Despawn -= Despawn;

        Pool.Add(spawnable);

        ObjectDespawned?.Invoke();
    }
}

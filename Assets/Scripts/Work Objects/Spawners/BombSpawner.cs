using UnityEngine;

public class BombSpawner : Spawner
{
    [SerializeField] private Explosive _explosive;

    public void PositionSpawn(Vector3 position)
    {
        transform.position = position;

        Spawn();
    }

    protected override void Despawn(Spawnable spawnable)
    {
        _explosive.Explode(spawnable);

        base.Despawn(spawnable);
    }
}

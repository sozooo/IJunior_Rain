using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private Explosive _explosive;

    public void PositionSpawn(Vector3 position)
    {
        transform.position = position;

        Bomb bomb = Spawn();
        bomb.Renderer.material.color = ObjectColor;
    }

    protected override void Despawn(Bomb spawnable)
    {
        _explosive.Explode(spawnable);

        base.Despawn(spawnable);
    }
}

using UnityEngine;
using System.Collections;

public class BombSpawner : Spawner
{
    [SerializeField] private Explosive _explosive;

    public void PositionSpawn(Vector3 position)
    {
        transform.position = position;

        Spawn();
    }

    public override Spawnable Spawn()
    {
        Bomb bomb =  base.Spawn() as Bomb;

        if(bomb != null)
        {
            bomb.Initialize(_explosive);
        }

        return bomb;
    }
}

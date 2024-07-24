using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class CubeSpawner : Spawner
{
    [Header("Positions")]
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxZ;
    [SerializeField] private float _minZ;

    public override Spawnable Spawn()
    {
        transform.position = new Vector3(Random.Range(_minX, _maxX), transform.position.y, Random.Range(_minZ, _maxZ));

        return base.Spawn();
    }
}

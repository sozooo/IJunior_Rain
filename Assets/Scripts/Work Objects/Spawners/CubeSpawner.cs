using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    [Header("Positions")]
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxZ;
    [SerializeField] private float _minZ;

    public override Cube Spawn()
    {
        transform.position = new Vector3(Random.Range(_minX, _maxX), transform.position.y, Random.Range(_minZ, _maxZ));

        Cube cube = base.Spawn();
        cube.Renderer.material.color = ObjectColor;

        return cube;
    }
}

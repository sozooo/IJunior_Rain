using UnityEngine;
using System.Collections.Generic;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private Queue<Cube> _cubes;

    private void Awake()
    {
        _cubes = new Queue<Cube>();
    }

    public void Add(Cube cube)
    {
        cube.gameObject.SetActive(false);
        _cubes.Enqueue(cube);
    }

    public Cube Take()
    {
        Cube cube;

        if(_cubes.Count == 0)
            cube = Instantiate(_cubePrefab);
        else
            cube = _cubes.Dequeue();

        return cube;
    }
}

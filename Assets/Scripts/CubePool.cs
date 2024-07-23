using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _minTimeToPool = 2;
    [SerializeField] private float _maxTimeToPool = 5;

    private Queue<Cube> _cubes;

    private void Awake()
    {
        _cubes = new Queue<Cube>();
    }

    public void Add(Cube cube)
    {
        cube.Collided -= StartTimer;

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

        cube.Collided += StartTimer;

        return cube;
    }

    public void Reset()
    {
        _cubes.Clear();
    }

    private void StartTimer(Cube cube)
    {
        float _timeToPool = Random.Range(_minTimeToPool, _maxTimeToPool + 1);

        StartCoroutine(Timer(cube, _timeToPool));
    }

    private IEnumerator Timer(Cube cube, float time)
    {
        yield return new WaitForSeconds(time);

        Add(cube);
    }
}

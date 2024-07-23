using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CubePool))]
public class Spawner : MonoBehaviour
{
    [SerializeField] float _spawnPeriod;

    [Header("Positions")]
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxZ;
    [SerializeField] private float _minZ;

    private CubePool _pool;
    private Coroutine _timer;

    private void Awake()
    {
        _pool = GetComponent<CubePool>();
    }

    private void OnEnable()
    {
        _timer = StartCoroutine(Timer());
    }

    private void OnDisable()
    {
        StopCoroutine(_timer);
    }

    private void Spawn()
    {
        transform.position = new Vector3(Random.Range(_minX, _maxX), transform.position.y, Random.Range(_minZ, _maxZ));

        Cube cube = _pool.Take();

        cube.Renderer.material.color = Color.white;
        cube.Despawn += Despawn;
        cube.gameObject.SetActive(true);

        cube.transform.position = transform.position;
    }

    private void Despawn(Cube cube)
    {
        _pool.Add(cube);
    }

    private IEnumerator Timer()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnPeriod);

        while (gameObject.activeSelf)
        {
            yield return wait;

            Spawn();
        }
    }
}

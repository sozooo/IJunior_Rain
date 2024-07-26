using UnityEngine;
using System.Collections;

public class SpawnersHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;

    [SerializeField] float _spawnPeriod;

    private void OnEnable()
    {
        StartCoroutine(Timer());
    }

    private void SpawnBomb(Cube cube)
    {
        cube.Despawn -= SpawnBomb;
        _bombSpawner.PositionSpawn(cube.transform.position);
    }

    private IEnumerator Timer()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnPeriod);

        while (gameObject.activeSelf)
        {
            yield return wait;

            _cubeSpawner.Spawn().Despawn += SpawnBomb;
        }
    }
}

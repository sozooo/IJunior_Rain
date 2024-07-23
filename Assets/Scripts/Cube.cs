using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _minTimeToPool = 2;
    [SerializeField] private float _maxTimeToPool = 5;

    private Renderer _renderer;
    private Coroutine _timer;

    public event Action<Cube> Despawn;

    public Renderer Renderer => _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Platform platform))
        {
            if (_timer == null)
            {
                SetRandomColor();
                StartTimer();
            }
        }
    }

    private void OnDisable()
    {
        _timer = null;
    }

    private void SetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }

    private void StartTimer()
    {
        float timeToPool = Random.Range(_minTimeToPool, _maxTimeToPool + 1);

        _timer = StartCoroutine(Timer(timeToPool));
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        Despawn?.Invoke(this);
    }
}

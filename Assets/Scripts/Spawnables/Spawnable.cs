using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Spawnable : MonoBehaviour
{
    [SerializeField] private float _minTimeToPool = 2;
    [SerializeField] private float _maxTimeToPool = 5;

    private Renderer _renderer;
    protected Coroutine PoolTimer;

    public event Action<Spawnable> Despawn;

    public Renderer Renderer => _renderer;
    public Rigidbody Body { get; private set; }

    protected void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Body = GetComponent<Rigidbody>();
    }

    protected void OnDisable()
    {
        PoolTimer = null;
    }

    protected void SetColor(Color color)
    {
        _renderer.material.color = color;
    }

    protected void StartTimer()
    {
        float timeToPool = Random.Range(_minTimeToPool, _maxTimeToPool + 1);

        PoolTimer = StartCoroutine(Timer(timeToPool));
    }

    protected void InvokeDespawn()
    {
        Despawn?.Invoke(this);
    }

    protected virtual IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        InvokeDespawn();
    }
}

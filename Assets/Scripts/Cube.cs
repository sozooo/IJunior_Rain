using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private Platform _collidedPlataform;
    private Renderer _renderer;

    public Renderer Renderer => _renderer;

    public event Action<Cube> Collided;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Platform platform))
        {
            if(_collidedPlataform == null)
            {
                _collidedPlataform = platform;

                SetRandomColor();
                Collided?.Invoke(this);
            }
        }
    }

    public void SetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}

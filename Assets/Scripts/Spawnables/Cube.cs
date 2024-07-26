using UnityEngine;

public class Cube : Spawnable, ISpawnable<Cube>
{
    public event System.Action<Cube> Despawn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Platform platform))
        {
            if (PoolTimer == null)
            {
                SetColor(Random.ColorHSV());
                StartTimer();
            }
        }
    }

    protected override void InvokeDespawn()
    {
        Despawn?.Invoke(this);
    }
}

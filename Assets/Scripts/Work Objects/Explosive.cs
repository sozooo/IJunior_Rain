using UnityEngine;
using System.Collections.Generic;

public class Explosive : MonoBehaviour
{
    [SerializeField] private float _explosionRange;
    [SerializeField] private float _explosionForce;
    [SerializeField] private LayerMask _spawnableLayer;

    public void Explode(Spawnable spawnable)
    {
        Vector3 position = spawnable.transform.position;

        foreach (Rigidbody body in GetCollidedBodies(position))
        {
            body.AddExplosionForce(_explosionForce, position, _explosionRange);
        }
    }

    private List<Rigidbody> GetCollidedBodies(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, _explosionRange, _spawnableLayer);

        List<Rigidbody> spawnables = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                spawnables.Add(hit.attachedRigidbody);
            }
        }

        return spawnables;
    }
}

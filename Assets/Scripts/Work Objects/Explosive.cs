using UnityEngine;
using System.Collections.Generic;

public class Explosive : MonoBehaviour
{
    [SerializeField] private float _explosionRange;
    [SerializeField] private float _explosionForce;
    [SerializeField] private LayerMask _spawnableLayer;

    Vector3 position;

    public void Explode(Bomb bomb)
    {
        position = bomb.transform.position;

        foreach (Rigidbody body in GetCollidedBodies())
        {
            body.AddExplosionForce(_explosionForce, position, _explosionRange);
        }
    }

    private List<Rigidbody> GetCollidedBodies()
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

    private void OnDrawGizmos()
    {
        Color gizmosColor = Color.red;
        gizmosColor.a /= 3;

        Gizmos.color= gizmosColor;

        Gizmos.DrawSphere(position, _explosionRange);
    }
}

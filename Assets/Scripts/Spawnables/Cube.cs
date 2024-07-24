using UnityEngine;


public class Cube : Spawnable
{
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
}

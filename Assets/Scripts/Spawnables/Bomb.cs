using UnityEngine;
using System.Collections;

public class Bomb : Spawnable
{
    private Explosive _explosive;

    private void OnEnable()
    {
        StartTimer();
    }

    public void Initialize(Explosive explosive)
    {
        _explosive = explosive;
    }

    protected override IEnumerator Timer(float time)
    {
        WaitForEndOfFrame wait = new();
        float currentTime = 0;
        Color temporaryColor;

        float _maxOpacity = 1;
        float _minOpacity = 0;

        while (currentTime <= time)
        {
            currentTime += Time.deltaTime;
            temporaryColor = Renderer.material.color;

            temporaryColor.a = Mathf.Lerp(_maxOpacity, _minOpacity, currentTime / time);
            Renderer.material.color = temporaryColor;

            yield return null;
        }

        _explosive.Explode(this);

        InvokeDespawn();
    }
}

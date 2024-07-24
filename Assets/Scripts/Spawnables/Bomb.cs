using UnityEngine;
using System.Collections;

public class Bomb : Spawnable
{
    private void OnEnable()
    {
        StartTimer();
    }

    protected override IEnumerator Timer(float time)
    {
        float currentTime = 0;
        Color temporaryColor;

        float maxOpacity = 1;
        float minOpacity = 0;

        while (currentTime <= time)
        {
            currentTime += Time.deltaTime;
            temporaryColor = Renderer.material.color;

            temporaryColor.a = Mathf.Lerp(maxOpacity, minOpacity, currentTime / time);
            Renderer.material.color = temporaryColor;

            yield return null;
        }

        InvokeDespawn();
    }
}

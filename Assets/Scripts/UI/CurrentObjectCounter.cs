using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CurrentObjectCounter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private TextMeshProUGUI _text;
    private int _currentCount = 0;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _spawner.ObjectSpawned += Increase;
        _spawner.ObjectDespawned += Decrease;
    }

    private void OnDisable()
    {
        _spawner.ObjectSpawned -= Increase;
        _spawner.ObjectDespawned -= Decrease;
    }

    private void Increase()
    {
        _currentCount++;
        Display();
    }

    private void Decrease()
    {
        _currentCount--;
        Display();
    }

    private void Display()
    {
        _text.text = _currentCount.ToString();
    }
}

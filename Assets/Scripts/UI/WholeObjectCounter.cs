using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class WholeObjectCounter : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private TextMeshProUGUI _text;
    private int _currentCount = 0;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _pool.ObjectTaken += Increase;
    }

    private void OnDisable()
    {
        _pool.ObjectTaken -= Increase;
    }

    private void Increase()
    {
        _currentCount++;
        Display();
    }

    private void Display()
    {
        _text.text = _currentCount.ToString();
    }
}

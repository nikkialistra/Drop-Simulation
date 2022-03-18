using System.Collections.Generic;
using UnityEngine;

public class RandomSequence : MonoBehaviour
{
    [SerializeField] private int _maxValue = 10_000;

    private readonly Queue<float> _values = new();
    
    public bool NotEmpty => _values.Count != 0;

    public void Clear()
    {
        _values.Clear();
    }

    public void Enqueue(float value)
    {
        _values.Enqueue(value / _maxValue);
    }

    public float Dequeue()
    {
        return _values.Dequeue();
    }

    public void Show()
    {
        while (_values.Count > 0)
        {
            Debug.Log(_values.Dequeue());
        }
    }
}
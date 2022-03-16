using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Simulation : MonoBehaviour
{
    [SerializeField] private Drop _drop;
    [Range(0.05f, 1f)]
    [SerializeField] private float _tickTime;

    private int _height;

    private Probabilities _probabilities = new Probabilities();
    
    private Coroutine _simulateCoroutine;

    public event Action<float, float, float, float> ValuesChange;

    public float TickTime
    {
        set => _tickTime = value;
    }

    public float Up { get; set; }
    public float Down { get; set; }
    public float Left { get; set; }
    public float Right { get; set; }

    public void SetHeight(int value)
    {
        _height = value;
        _drop.SetHeight(_height);
    }

    public void StartSimulation()
    {
        Reset();
        NormalizeValuesSum();
        CalculateProbabilities();
        _simulateCoroutine = StartCoroutine(Simulate());
    }

    private void NormalizeValuesSum()
    {
        var sum = Up + Down + Left + Right;

        if (sum == 0)
        {
            return;
        }
        
        if (Math.Abs(sum - 1) > 0.01f)
        {
            Up /= sum;
            Down /= sum;
            Left /= sum;
            Right /= sum;
            
            ValuesChange?.Invoke(Up, Down, Left, Right);
        }
    }

    private void CalculateProbabilities()
    {
        _probabilities.Up = Up;
        _probabilities.Down = _probabilities.Up + Down;
        _probabilities.Left = _probabilities.Down + Left;
        _probabilities.Right = _probabilities.Left + Right;
    }

    public void StopSimulation()
    {
        Reset();
    }

    private void Reset()
    {
        _drop.SetHeight(_height);
        
        if (_simulateCoroutine != null)
        {
            StopCoroutine(_simulateCoroutine);
        }
    }

    private IEnumerator Simulate()
    {
        _drop.TickTime = _tickTime - (_tickTime / 15);
        while (_drop.IsFalling())
        {
            Tick();
            
            yield return new WaitForSeconds(_tickTime);
        }
    }

    private void Tick()
    {
        var randomValue = Random.value;

        if (randomValue <= _probabilities.Up)
        {
            _drop.Up();
        }
        else if (randomValue <= _probabilities.Down)
        {
            _drop.Down();
        }
        else if (randomValue <= _probabilities.Left)
        {
            _drop.Left();
        }
        else if (randomValue <= _probabilities.Right)
        {
            _drop.Right();
        }
    }
    
    private class Probabilities
    {
        public float Up;
        public float Down;
        public float Left;
        public float Right;
    }
}
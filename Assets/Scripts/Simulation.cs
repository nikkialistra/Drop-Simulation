using System.Collections;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    [SerializeField] private Drop _drop;
    [Range(0.05f, 1f)]
    [SerializeField] private float _tickTime;

    private int _height;
    private int _currentHeight;
    
    private Coroutine _simulateCoroutine;

    public void SetHeight(int value)
    {
        _height = value;
        _drop.SetHeight(_height);
    }
    
    public float Up { get; set; }
    public float Down { get; set; }
    public float Left { get; set; }
    public float Right { get; set; }

    public void StartSimulation()
    {
        Reset();
        _simulateCoroutine = StartCoroutine(Simulate());
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
        _currentHeight = _height;
        while (_currentHeight > 0)
        {
            yield return new WaitForSeconds(_tickTime);
            
            Tick();
            _currentHeight--;
        }
    }

    private void Tick()
    {
        _drop.Down();
    }
}
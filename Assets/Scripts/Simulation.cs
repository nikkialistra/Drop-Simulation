using UnityEngine;

public class Simulation : MonoBehaviour
{
    public int Height { get; set; }

    public float Up { get; set; }
    public float Down { get; set; }
    public float Left { get; set; }
    public float Right { get; set; }

    public void StartSimulation()
    {
        Debug.Log($"{Height}, {Up}, {Down}, {Left}, {Right}");
    }
}
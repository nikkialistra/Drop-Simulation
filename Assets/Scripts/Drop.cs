using System.Collections;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private Coroutine _moveOverTickCoroutine;
    
    public float TickTime { get; set; }

    public void SetHeight(float value)
    {
        transform.position = new Vector3(0, value, 0);
    }

    public bool IsFalling()
    {
        return transform.position.y > 0;
    }

    public void Up()
    {
        var newPosition = new Vector3(transform.position.x, transform.position.y + 1, 0);
        var newRotation = Quaternion.identity;

        StartMovement(newPosition, newRotation, TickTime);
    }

    public void Down()
    {
        var newPosition = new Vector3(transform.position.x, transform.position.y - 1, 0);
        var newRotation = Quaternion.identity;
        
        StartMovement(newPosition, newRotation, TickTime);
    }

    public void Left()
    {
        var newPosition = new Vector3(transform.position.x - 1, transform.position.y, 0);
        var newRotation = Quaternion.Euler(new Vector3(0, 0, -30f));
        
        StartMovement(newPosition, newRotation, TickTime);
    }

    public void Right()
    {
        var newPosition = new Vector3(transform.position.x + 1, transform.position.y + 1, 0);
        var newRotation = Quaternion.Euler(new Vector3(0, 0, 30f));
        
        StartMovement(newPosition, newRotation, TickTime);
    }

    private void StartMovement(Vector3 newPosition, Quaternion newRotation, float tickTime)
    {
        if (_moveOverTickCoroutine != null)
        {
            StopCoroutine(_moveOverTickCoroutine);
        }

        _moveOverTickCoroutine = StartCoroutine(MoveOverTick(newPosition, newRotation, tickTime));
    }

    private IEnumerator MoveOverTick(Vector3 newPosition, Quaternion newRotation, float tickTime)
    {
        var elapsedTime = 0f;
        while (elapsedTime <= tickTime && IsFalling())
        {
            var fraction = elapsedTime / tickTime;
            
            transform.position = Vector3.Lerp(transform.position, newPosition, fraction);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, fraction);
            
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        if (newPosition.y >= 0)
        {
            transform.position = newPosition;
            transform.rotation = newRotation;
        }
    }
}
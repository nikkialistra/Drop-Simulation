using UnityEngine;

public class Drop : MonoBehaviour
{
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
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
    }
    
    public void Down()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
    }
    
    public void Left()
    {
        transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
    }
    
    public void Right()
    {
        transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, 0);
    }
}
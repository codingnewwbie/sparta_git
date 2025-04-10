using UnityEngine;

public class Shield : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}

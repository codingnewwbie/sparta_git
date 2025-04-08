using UnityEngine;

public class Rtan : MonoBehaviour
{

    float direction = 0.05f;

    SpriteRenderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0)) {
            direction *= -1;
            renderer.flipX = !renderer.flipX;
        }

        if(transform.position.x > 2.6) {
            direction = -0.05f;
            renderer.flipX = true;
        } 

        transform.position += Vector3.right * direction;

        if(transform.position.x < -2.6)  {
            direction = 0.05f;
            renderer.flipX = false;
        }
    }
}

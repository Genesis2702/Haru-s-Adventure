using UnityEngine;

public class HaruMenuMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float speed = 6.0f;
    private Vector2 initialPosition = new Vector3(-11, -3.5f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        LoopMoving();
    }

    private void LoopMoving()
    {
        if (transform.position.x > 11)
        {
            speed *= -1;
            spriteRenderer.flipX = true;
        }
        else if (transform.position.x < -11)
        {
            speed *= -1;
            spriteRenderer.flipX = false;
        }
    }

}

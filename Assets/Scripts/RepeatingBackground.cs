using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private float speed = 5.0f;
    private Vector2 originalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < originalPosition.x - 17.785f)
        {
            transform.position = originalPosition;
        }
    }
}

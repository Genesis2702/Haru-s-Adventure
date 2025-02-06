using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BalloonMovement : MonoBehaviour
{
    private float speed = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        OutOfBoundCheck();
    }

    private void OutOfBoundCheck()
    {
        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}

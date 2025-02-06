using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float speed = 6.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        OutOfBoundCheck();
    }

    private void OutOfBoundCheck()
    {
        if (transform.position.x > 9)
        {
            Destroy(gameObject);
        }
    }
}

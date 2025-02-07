using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float speed = 6.0f;
    private PlayerController playerControllerScript;
    private GameManager gameManagerScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManagerScript.inOptionMenu)
        {
            if (playerControllerScript.isAlive)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                OutOfBoundCheck();
            }
        }
    }

    private void OutOfBoundCheck()
    {
        if (transform.position.x > 9)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon") || other.CompareTag("Bomb") || other.CompareTag("Buff"))
        {
            Destroy(gameObject);
        }
    }
}

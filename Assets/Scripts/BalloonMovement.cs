using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BalloonMovement : MonoBehaviour
{
    private float speed = 3.0f;
    public int value;
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
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                OutOfBoundCheck();
            }
        }
    }

    private void OutOfBoundCheck()
    {
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && gameObject.CompareTag("Balloon"))
        {
            Destroy(gameObject);
            gameManagerScript.ScoreUpdating(value);
        }
        else if (other.CompareTag("Bullet") && gameObject.CompareTag("Bomb"))
        {
            playerControllerScript.lives--;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet") && gameObject.CompareTag("Buff"))
        {   
            Destroy(gameObject);
            gameManagerScript.multiplier = 2;
        }
    }
}

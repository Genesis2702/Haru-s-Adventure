using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private float speed = 5.0f;
    private Vector2 originalPosition;
    private PlayerController playerControllerScript;
    private GameManager gameManagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;
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
                if (transform.position.x < originalPosition.x - 17.785f)
                {
                    transform.position = originalPosition;
                }
            }
        }
    }
}

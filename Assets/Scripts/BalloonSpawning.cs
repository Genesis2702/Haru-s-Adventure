using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawning : MonoBehaviour
{
    public List<GameObject> balloons;
    public GameObject x2Balloon;
    public GameObject skullBalloon;
    private PlayerController playerControllerScript;
    private GameManager gameManagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawningBalloons", 4.0f, 0.5f);
        InvokeRepeating("SpawningSkullBalloons", 10.0f, Random.Range(4.0f, 8.0f));
        InvokeRepeating("SpawningX2Balloons", 25.0f, Random.Range(9.0f, 13.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawningBalloons()
    {
        if (!gameManagerScript.inOptionMenu)
        {
            if (playerControllerScript.isAlive)
            {
                int balloonIndex = Random.Range(0, 3);
                Instantiate(balloons[balloonIndex], new Vector2(10, Random.Range(-4.0f, 4.1f)), balloons[balloonIndex].gameObject.transform.rotation);
            }
        }
    }

    private void SpawningX2Balloons()
    {
        if (!gameManagerScript.inOptionMenu)
        {
            if (playerControllerScript.isAlive)
            {
                Instantiate(x2Balloon, new Vector2(10, Random.Range(-4.0f, 4.1f)), x2Balloon.gameObject.transform.rotation);
            }
        }
    }

    private void SpawningSkullBalloons()
    {
        if (!gameManagerScript.inOptionMenu)
        {
            if (playerControllerScript.isAlive)
            {
                Instantiate(skullBalloon, new Vector2(10, Random.Range(-4.0f, 4.1f)), skullBalloon.gameObject.transform.rotation);
            }
        }
    }
}

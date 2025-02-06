using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawning : MonoBehaviour
{
    public List<GameObject> balloons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawningBalloons", 3.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawningBalloons()
    {
        int balloonIndex = Random.Range(0, 3);
        Instantiate(balloons[balloonIndex], new Vector2(Random.Range(1.0f, 8.0f), -7), balloons[balloonIndex].gameObject.transform.rotation);
    }
}

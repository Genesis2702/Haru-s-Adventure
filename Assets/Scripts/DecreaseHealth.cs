using UnityEngine;

public class DecreaseHealth : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private Animator healthAnimation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        healthAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthAnimation.SetInteger("lives", playerControllerScript.lives);
    }
}

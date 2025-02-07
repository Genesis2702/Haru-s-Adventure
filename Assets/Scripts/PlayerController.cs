using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 0.15f;
    private float fireRate = 0.3f;
    private bool shootAllow = true;
    public int lives;
    public bool isAlive;
    public GameObject bullet;
    private Vector2 initialPosition = new Vector2(-7, 0);
    public AudioClip bulletSound;
    private AudioSource playerAudio;
    private GameManager gameManagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
        isAlive = true;
        lives = 6;
        SetInitialPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManagerScript.inOptionMenu)
        {
            if (isAlive)
            {
                MovementControl();
                OutOfBoundCheck();
                if (Input.GetKeyDown(KeyCode.Space) && shootAllow)
                {
                    playerAudio.PlayOneShot(bulletSound, 3.0f);
                    StartCoroutine(ShootingBullet());
                } 
            }   
            if (lives == 0)
            {
                isAlive = false;
            }
        }
    }

    IEnumerator ShootingBullet()
    {
        Instantiate(bullet, transform.position + new Vector3(0.675f, -0.105f), bullet.gameObject.transform.rotation);
        shootAllow = false;
        yield return new WaitForSeconds(fireRate);
        shootAllow = true;
    }

    private void MovementControl()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * verticalInput * speed);
    }

    private void SetInitialPosition()
    {
        transform.position = initialPosition;
    }

    private void OutOfBoundCheck()
    {
        if (transform.position.y > 4)
        {
            transform.position = new Vector2(transform.position.x, 4);
        }
        else if (transform.position.y < -4)
        {
            transform.position = new Vector2(transform.position.x, -4);
        }
    }
}

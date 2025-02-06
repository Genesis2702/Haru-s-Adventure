using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 0.1f;
    private float fireRate = 0.3f;
    private bool shootAllow = true;
    public GameObject bullet;
    private Vector2 initialPosition = new Vector2(-7, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetInitialPosition();
    }

    // Update is called once per frame
    void Update()
    {
        MovementControl();
        OutOfBoundCheck();
        if (Input.GetKeyDown(KeyCode.Space) && shootAllow)
        {
            StartCoroutine(ShootingBullet());
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

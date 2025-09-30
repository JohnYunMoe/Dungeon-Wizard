using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handrotate : MonoBehaviour
{
    //for movement
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    public float movementSpeed;
    //for the bullet 
    public Transform firePoint;
    public GameObject bullet;
    public float timeBetweenShots;
    public float shotCounter;
    public GameObject speedboost;
    public int shotcount;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 4;
        rb = gameObject.GetComponent<Rigidbody2D>();
        speedboost = GameObject.FindGameObjectWithTag("speedboost");
        shotcount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }
    void LookAtMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 mouseDistance = mousePos - screenPos;
        float angle = Mathf.Atan2(mouseDistance.y, mouseDistance.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        fireball(shotcount);
    }

    void fireball(int shotcount)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (shotcount == 1)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
            }

            if (shotcount == 2)
            {
                StartCoroutine(MultiShotCoroutine());
            }
        }
    }

    private IEnumerator MultiShotCoroutine()
    {
        // First bullet
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(0.2f); // Adjust delay as needed

        // Second bullet
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("speedboost"))
        {
            Debug.Log("Speedboost collected!");
            shotcount = 2;
            Destroy(collision.gameObject);
        }
    }


}

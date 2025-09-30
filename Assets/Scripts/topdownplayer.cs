using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class topdownplayer : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal; 
    float vertical;
    public float movementSpeed;
    Animator anim;

    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 4;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Xinput", horizontal);
        anim.SetFloat("Yinput", vertical);

        if (horizontal == 0 && vertical == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        if (horizontal > 0 && !facingRight)
        {
            Flip(); 
        }
        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }

    void Flip()
    {
        facingRight = !facingRight; // Toggle the direction
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Flip the x scale
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            anim.Play("Death_Player");
        }
    }
    public void OnAnimationEnd()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(4);
    }
}

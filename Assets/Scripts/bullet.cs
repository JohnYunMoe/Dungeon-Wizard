using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public GameObject impactEffect; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * moveSpeed; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        //Instantiate(impactEffect, transform.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChase : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float speed;
    Animator anim; 

    private float distance; 
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if (player == null)
        {
            player = GameObject.FindWithTag("Player"); // Ensure the Player has a "Player" tag
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();


        if (distance < 9)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = gameObject.GetComponent<Collider2D>();
        collider.enabled = false; // Disables the collider
        anim.Play("Death_Enemy");   
    }
    public void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class camerafollow : MonoBehaviour
{
    public GameObject player;
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float cameraLerp = speed * Time.deltaTime;
        Vector3 tempPos = transform.position;
        tempPos.x = Mathf.Lerp(transform.position.x, player.transform.position.x, cameraLerp);
        tempPos.y = Mathf.Lerp(transform.position.y, player.transform.position.y, cameraLerp);

        transform.position = tempPos;

        if (transform.position.x > 3)
        {
            transform.position = new Vector3(3, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -3)
        {
            transform.position = new Vector3(-3, transform.position.y, transform.position.z);
        }

        if (transform.position.y > 4)
        {
            transform.position = new Vector3(transform.position.x, 4, transform.position.z);
        }

        if (transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, transform.position.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float timer;
    public float room1enemy;
    public float room2enemy;
    public float room3enemy;
    public GameObject Enemy;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        timer = 2f;
        room1enemy = 10;
        room2enemy = 10;
        room3enemy = 10;
        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if ((room1enemy + room2enemy + room3enemy) > 0)
        {
            SpawnEnemy();
        }

        if (SceneManager.GetActiveScene().name == "Room1" && room1enemy <= 0)
        {
            SceneManager.LoadScene(5);
        }

        if (SceneManager.GetActiveScene().name == "Room2" && room2enemy <= 0)
        {
            SceneManager.LoadScene(6);
        }

        if (SceneManager.GetActiveScene().name == "Room3" && room3enemy <= 0)
        {
            SceneManager.LoadScene(3);
        }

    }


    public void SpawnEnemy()
    {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Vector3 spawnPosition = new Vector3(
                    Random.Range(gameObject.transform.position.x, gameObject.transform.position.x + 2),
                    gameObject.transform.position.y,
                    0);
                Vector3 spawnPosition2 = new Vector3(
                    Random.Range(gameObject.transform.position.x, gameObject.transform.position.x + 2),
                    gameObject.transform.position.y - 7,
                    0);

                Instantiate(Enemy, spawnPosition, Quaternion.identity);
                if (SceneManager.GetActiveScene().name == "Room1")
                {
                    room1enemy--;
                }
                if (SceneManager.GetActiveScene().name == "Room2")
                {
                    room2enemy--;
                }
                if (SceneManager.GetActiveScene().name == "Room3")
                {
                    room3enemy--;
                }
                Instantiate(Enemy, spawnPosition2, Quaternion.identity);
                if (SceneManager.GetActiveScene().name == "Room1")
                {
                    room1enemy--;
                }
                if (SceneManager.GetActiveScene().name == "Room2")
                {
                    room2enemy--;
                }
                if (SceneManager.GetActiveScene().name == "Room3")
                {
                    room3enemy--;
                }
                timer = Random.Range(2f, 6f); 
            }
    }

}

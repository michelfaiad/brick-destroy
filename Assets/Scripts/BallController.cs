using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float startSpeed = 5f;

    [SerializeField]
    GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        if (!GameManager.isGameStarted())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                canvas.SetActive(false);
                GetComponent<Rigidbody2D>().velocity = (Vector2.up + Vector2.right) * startSpeed;
                GameManager.startGame();
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("brick"))
        {
            GameManager.inst.addScore(100);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gameOver"))
        {
            GameManager.endGame();
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        } else if (other.CompareTag("star"))
        {
            GameManager.inst.onSpecialItemCollision(other.gameObject);
        }


    }


}

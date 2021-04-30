using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    [SerializeField]
    protected GameObject prefabSpecialItem, paddle;

    [SerializeField]
    TextMeshProUGUI scoreText;

    int score = 0;

    public static bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnItem", Random.Range(7, 15));
        
        if (inst == null)
        {
            inst = this;
        }

        scoreText.text = score.ToString();
    }

    protected void spawnItem()
    {
        GameObject specialItem = Instantiate(prefabSpecialItem);
        specialItem.transform.position = new Vector2(Random.Range(-7, 7), Random.Range(1, -3));
    }

    public void addScore(int scoreIncrement)
    {
        score += scoreIncrement;
        scoreText.text = score.ToString();
    }

    public void onSpecialItemCollision(GameObject other)
    {
        Vector2 size = paddle.GetComponent<SpriteRenderer>().size;
        if (size.x <= 5)
            size.x += 1;

        paddle.GetComponent<SpriteRenderer>().size = size;
        paddle.GetComponent<CapsuleCollider2D>().size = size;

        Destroy(other);

        Invoke("spawnItem", Random.Range(7, 15));
    }

    public static bool isGameStarted()
    {
        return gameStarted;
    }

    public static void startGame()
    {
        gameStarted = true;
    }

    public static void endGame()
    {
        gameStarted = false;
    }

}

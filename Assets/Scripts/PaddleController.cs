using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    float speed = 1.5f;

    float paddleLimit = 8.5f;

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameStarted())
        {
            Vector2 currentPosition = transform.position;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                currentPosition.x += speed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                currentPosition.x -= speed;
            }

            if (currentPosition.x >= -paddleLimit + (sprite.size.x / 2) && currentPosition.x <= paddleLimit - (sprite.size.x / 2))
                GetComponent<Rigidbody2D>().MovePosition(currentPosition);
        }
    }
}

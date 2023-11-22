using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerController;
    private float leftBound = -15;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerController.gameOver)
        {
            if (playerController.dash)
            {
                transform.Translate(speed * 2 * Time.deltaTime * Vector3.left);

            }
            else
            {
                transform.Translate(speed * Time.deltaTime * Vector3.left);
            }
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

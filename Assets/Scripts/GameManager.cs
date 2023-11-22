using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score;
    private PlayerController playerController;
    public Transform startingPoint;
    public float lerpSpeed;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;

        playerController.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerController.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;

        playerController.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerController.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }

        playerController.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        playerController.gameOver = false;
    }


    void Update()
    {
        if (!playerController.gameOver)
        {
            if (playerController.dash)
            {
                score += 2;
            }
            else
            {
                score++;
            }

            Debug.Log("Score: " + score);
        }
    }
}

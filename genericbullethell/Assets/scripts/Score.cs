using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author: [Richards, Sam]
 * Last Updated: [12/5/2024]
 * [calculates and prints score]
 */

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerCollision damage;
    public TMP_Text scoreDisplay;
    public float score;
    private bool canAddTimeScore;
    public float addScoreSeconds;
    private string displayedScore;
    public float scoreMultiplier;
    private bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        canAddTimeScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
        }
        damage = player.GetComponent<PlayerCollision>();
        displayedScore = score.ToString("00000000");
        scoreDisplay.text = "Score:" + displayedScore;
        if (gameStarted)
        {
            StartCoroutine(ScoreCalc());
        }
    }
    //adds score up :>
    IEnumerator ScoreCalc()
    {
        if (damage.lives > 0)
        {
            if (canAddTimeScore)
            {
                canAddTimeScore = false;
                yield return new WaitForSeconds(addScoreSeconds);
                score += 1 * scoreMultiplier;
                canAddTimeScore = true;
            }
            if (damage.lostLife)
            {
                damage.lostLife = false;
                score -= score * 0.2f;
            }
        }
    }
}

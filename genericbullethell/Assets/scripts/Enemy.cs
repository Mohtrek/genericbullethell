using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author: [Richards, Sam]
 * Last Updated: [12/9/2024]
 * [handles enemy movements and starts attacks]
 */

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject cameraRef;
    public bool moveEnemy;
    public bool canAttack;
    public bool enemyRest;
    public float timeTilStart;
    public float enemySpeed;
    public float slowedSpeed;
    public float enemyHealth;
    private float currentSpeed;
    public float restTime;
    public float timeUntilFirstAttack;
    public bool restDuringAttack;
    public float cameraYToStart;
    public Vector2 endPos;
    private RunAttack startAttack;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Funny", timeTilStart, restTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraYToStart <= cameraRef.transform.position.y)
        {
            Move();
            Attack();
        }
    }


    private void Move()
    {
        StartCoroutine(PauseMove(timeTilStart));
        startAttack = GetComponent<RunAttack>();
        moveEnemy = true;
        currentSpeed = enemySpeed;
        if (restDuringAttack)
        {
            if (startAttack.isRunning)
            {
                currentSpeed = slowedSpeed;
            }
            else
            {
                currentSpeed = enemySpeed;
            }
        }
        if (moveEnemy)
        {
            if (enemyRest)
            {
                StartCoroutine(PauseMove(restTime));
                
            }
            this.transform.position = Vector2.MoveTowards(this.transform.position, endPos, currentSpeed * Time.deltaTime);

        }
        StartCoroutine(TimeAttack());
    }

    private void Attack()
    {
        StartCoroutine(TimeAttack());
    }

    private void Funny()
    {
        print("hi");
    }

    private IEnumerator PauseMove(float rest)
    {
        moveEnemy = false;
        yield return new WaitForSeconds(rest);
        enemyRest = false;
        moveEnemy = true;
    }

    private IEnumerator TimeAttack()
    {
        yield return new WaitForSeconds(timeUntilFirstAttack);
        canAttack = true;
        if (canAttack)
        {
            startAttack.timeToAttack = true;
        }
    }
}

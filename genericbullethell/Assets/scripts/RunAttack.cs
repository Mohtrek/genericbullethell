using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Richards, Sam]
 * Last Updated: [11/30/2024]
 * [runs through each attack in the array, runs attack function in each then waits]
 */

public class RunAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] attacks;
    [SerializeField] private GameObject target;
    private Bullets startAttack;
    public bool isRunning;
    public bool inBounds;
    [HideInInspector] public bool timeToAttack;
    [HideInInspector] public float targetAngle;

    // Update is called once per frame
    void Update()
    {
        targetAngle = Mathf.Atan2(target.transform.position.y - this.transform.position.y, target.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
        if (timeToAttack && !isRunning && inBounds)
        {
            StartCoroutine(RunAttacks());
        }
    }

    //for loop runs through each gameobject in the array, runs attack function in each script,
    //waits until the function is done, then rests before next attack
    IEnumerator RunAttacks()
    {
        isRunning = true;
        for (int index = 0; index < attacks.Length; index++)
        {
            if (attacks[index] != null)
            {
                startAttack = attacks[index].GetComponent<Bullets>();
                startAttack.Attack();
                yield return new WaitUntil(() => startAttack.isShooting == false);
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(startAttack.rest);
        }
        inBounds = false;
        isRunning = false;
    }
}

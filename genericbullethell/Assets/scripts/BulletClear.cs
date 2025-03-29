using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Richards, Sam]
 * Last Updated: [12/5/2024]
 * [clears all bullets, adds score for each bullet]
 */

public class BulletClear : MonoBehaviour
{
    public bool addsScore;
    public bool clear;
    [SerializeField] private Score scoreHandler; 
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (clear)
            {
                if (addsScore)
                {
                    scoreHandler.score += 1 * scoreHandler.scoreMultiplier;
                }
                Destroy(other.gameObject);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<RunAttack>().inBounds = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<RunAttack>().inBounds = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //debug
        if (Input.GetKey(KeyCode.C))
        {
            clear = true;
        }
        else
        {
            clear = false;
        }
    }
}

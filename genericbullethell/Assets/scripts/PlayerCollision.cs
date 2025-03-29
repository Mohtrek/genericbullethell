using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Richards, Sam]
 * Last Updated: [12/5/2024]
 * [handles bullets damaging player]
 */

public class PlayerCollision : MonoBehaviour
{
    public float totalHealth;
    [HideInInspector] public float currentHealth;
    public int lives;
    public float damageMultiplier;
    [HideInInspector] public bool lostLife = false;
    [HideInInspector] public bool tookDamage = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            currentHealth -= 1 * damageMultiplier;
            tookDamage = true;
            if (currentHealth <= 0)
            {
                LoseLife();
            }
        }
    }

    //subtracts life when hp = 0
    private void LoseLife()
    {
        lives--;
        lostLife = true;
        if (lives == 0)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            currentHealth = totalHealth;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/*
 * Author: [Lazaro, Marc]
 * Last Updated: [12/3/24]
 * [This will create the lives for the player]
 *
 */
public class Lives : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text healthText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + GetComponentInParent<PlayerCollision>().lives;
        healthText.text = "Health: " + GetComponentInParent<PlayerCollision>().currentHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Richards, Sam]
 * Last Updated: [12/1/2024]
 * [destroys bullets when they enter collision]
 */

public class BulletDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Richards, Sam]
 * Last Updated: [12/11/2024]
 * [hides start prompt when space is pressed]
 */

public class StartPrompt : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
        }
    }
}

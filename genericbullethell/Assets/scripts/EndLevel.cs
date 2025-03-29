using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Richards, Sam]
 * Last Updated: [12/11/2024]
 * [sends player to level select upon completion of level]
 */

public class EndLevel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y == this.GetComponent<CameraMove>().endPos.y)
        {
            SceneManager.LoadScene(5);
        }
    }
}

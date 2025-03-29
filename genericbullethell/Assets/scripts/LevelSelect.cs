using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Richards, Sam]
 * Last Updated: [12/11/2024]
 * [loads level as specified by button]
 */

public class LevelSelect : MonoBehaviour
{
    // Update is called once per frame
    public void SwitchScreen(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

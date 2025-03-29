using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Lazaro, Marc]
 * Last Updated: [12/3/24]
 * [This will make a title screen]
 *
 */

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {

    }

    /// <summary>
    /// Change the current scene to the index
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void SwitchScreen(int sceneIndex)
    {
        SceneManager.LoadScene(5);
    }
}

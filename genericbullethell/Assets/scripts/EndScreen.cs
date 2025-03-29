using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Lazaro, Marc]
 * Last Updated: [12/3/24]
 * [This will make a game over screen]
 *
 */
public class EndScreen : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }


    /// <summary>
    /// Change the current scene to the index
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void SwitchScreen(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

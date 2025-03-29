using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/*
 * Author: [Richards, Sam]
 * Last Updated: [12/9/2024]
 * [moves the camera between two set points, allows for events to happen during levels]
 */

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed;
    public Vector2 endPos;
    public bool cameraRest;
    private bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            cameraRest = false;
            gameStarted = true;
        }
        if (!cameraRest)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, endPos, cameraSpeed * Time.deltaTime);
        }
    }
}

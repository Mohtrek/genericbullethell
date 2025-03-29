using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
/// <summary>
/// handles player movements and player linking to the camera
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    public float basePlayerSpeedX;
    public float basePlayerSpeedY;
    private float playerSpeedX;
    private float playerSpeedY;
    public float slowedSpeedX;
    public float slowedSpeedY;
    public Vector2 startPos;
    public Vector2 respawnPos;
    public float maxY;
    public float minY;
    public float maxX;
    public float minX;
    private CameraMove moveCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeedX = basePlayerSpeedX;
        playerSpeedY = basePlayerSpeedY;
    }

    // Update is called once per frame
    void Update()
    {
        
        moveCamera = GetComponentInParent<CameraMove>();

        Moving();
        SlowDown();
    }
    /// <summary>
    /// handles player movement
    /// </summary>
    /// 
    private void Moving()
    {
        float tempmaxY = moveCamera.transform.position.y + maxY;
        float tempminY = moveCamera.transform.position.y + minY;
        if (Input.GetKey(KeyCode.W) && transform.position.y < tempmaxY)
        {
            transform.position += Vector3.up * playerSpeedY * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > minX)
        {
            transform.position += Vector3.left * playerSpeedX * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > tempminY)
        {
            transform.position += Vector3.down * playerSpeedY * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
        {
            transform.position += Vector3.right * playerSpeedX * Time.deltaTime;
        }
    }

    /// <summary>
    /// slows player movement to allow easier dodging of more difficult attacks
    /// </summary>
    private void SlowDown()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerSpeedX = slowedSpeedX;
            playerSpeedY = slowedSpeedY;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            playerSpeedX = basePlayerSpeedX;
            playerSpeedY = basePlayerSpeedY;
        }
    }
}

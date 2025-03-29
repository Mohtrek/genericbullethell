using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author: [Richards, Sam]
 * Last Updated: [11/30/2024]
 * [handles spawning of bullets and gives trajectories to them]
 */

public class Bullets : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private RunAttack target;
    public int streamCount;
    public float streamDeltaAngle;
    public float bulletSpeed;
    public int bulletPerStream;
    public float timeBetweenBullets;
    public float rest = 1f;
    public float startAngle;
    public float deltaAngle;
    public bool aimTowardsTarget;
    public bool aimCenterBulletAtTarget;
    [HideInInspector] public bool isShooting;

    public void Attack()
    {
        isShooting = true;
        target = GetComponentInParent<RunAttack>();
        for (int index = 0; index < streamCount; index++)
        {
            StartCoroutine(ShootTime(target.targetAngle, streamDeltaAngle * index));
            //figure a way to add rest period
        }
    }

    private IEnumerator ShootTime(float targetAngle, float streamChange)
    {
        //adds the angle for each attack to start at
        float angle = startAngle + streamChange;
        //needs to be adjusted to work with streams
        //aims at target (player usually) if enabled
        if (aimTowardsTarget)
        {
            angle += targetAngle;
            if (aimCenterBulletAtTarget)
            {
                //adjusts so the center projectile is aimed at target
                angle -= deltaAngle * (bulletPerStream / 2);
            }
        }
        for (int index = 0; index < bulletPerStream; index++)
        {
            //resets angle so it doesn't exceed any integer limits
            if (angle >= 360)
            {
                angle -= 360;
            }
            if (angle <= -360)
            {
                angle += 360;
            }
            //instantiates projectiles
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            //sets projectiles to initial rotation, look into changing rotation if time
            newBullet.transform.Rotate(0.0f, 0.0f, angle);
            //reused math from my 2022 vrc robot
            //https://mohtrek.neocities.org/robots/johnmadden if you want to check that out
            //takes angle of bullets, converts it from degrees to radians,
            //then gets the sine and cosine of that value,
            //then runs those variables into the x and y input of the vector2
            //and multiplies them by bulletSpeed so they will have velocity
            //the sine and cosine functions will give an output between 1 and -1
            //so they'll tell the vector which direction to go.
            //sine is being used in the x input, cosine is being used in the y input
            float angleRadians = angle * Mathf.Deg2Rad;
            float bulletSin = Mathf.Cos(angleRadians);
            float bulletCos = Mathf.Sin(angleRadians);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(bulletSpeed * bulletSin, bulletSpeed * bulletCos));
            //changes angle of each projectile
            angle += deltaAngle;
            yield return new WaitForSeconds(timeBetweenBullets);
        }
        //reset angle after all bullets go out (idk if this is actually nessesary)
        angle = 0;
        isShooting = false;
    }
}

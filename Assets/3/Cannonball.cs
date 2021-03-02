using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private float initialVelocity = 3;
    private float angle = 5f;
    private float gravity = 1f;
    private float velocityZ;
    private float velocityY;
    private float startTime;

    private void OnEnable()
    {
        startTime = Time.time;
        velocityZ=0;
        velocityY=0;
        transform.localPosition = new Vector3(0, 0, 0);

     }

    private void FixedUpdate()
    {
        velocityZ = initialVelocity * Mathf.Cos(angle * Mathf.Deg2Rad) * 0.05f;
        velocityY = ((initialVelocity * Mathf.Sin(angle * Mathf.Deg2Rad)) - gravity * (Time.time - startTime)) * 0.05f;

        UpdateCannonballPosition();

        if (this.transform.localPosition.y < -6f)
            this.gameObject.SetActive(false);

    }

    private void UpdateCannonballPosition( )
    {
        Transform t = this.transform;

        if(t.position.y > -0.5f)
        {
            t.localPosition = new Vector3(t.localPosition.x, t.localPosition.y + velocityY, t.localPosition.z + velocityZ);
        }
    }
}

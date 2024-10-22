using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CannonController : MonoBehaviour
{
    [Header("Inscribed")]
    public float cannonballSpeed;


    [Header("Dynamic")]
    public GameObject cannonBallType1;
    public GameObject cannonBallType2;
    public GameObject cannonBallType3;
    public float angle = 0;
    public float barrelLength = .75f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 direction = mousePos3D - transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(Mathf.Abs(angle - 90) < 85)
        {
            transform.rotation = Quaternion.Euler(0, 0, (angle - 90));

        }

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            ShootCannonball(cannonBallType1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)){
            ShootCannonball(cannonBallType2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)){
            ShootCannonball(cannonBallType3);
        }
    }

    private void ShootCannonball(GameObject cannonballPrefab)
    {
        // Calculate the spawn position at the end of the barrel
        Vector3 spawnPosition = transform.position + transform.up * barrelLength;

        // Instantiate the cannonball at the cannon's position and rotation
        GameObject cannonball = Instantiate(cannonballPrefab, transform.position, transform.rotation);

        //// Add force to the cannonball (optional, you can adjust the force as needed)
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.up * cannonballSpeed;
        }
    }
}

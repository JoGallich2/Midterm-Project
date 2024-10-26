using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class CannonController : MonoBehaviour
{
    [Header("Inscribed")]
    public float angle = 0f;
    public float rotationSpeed = 5f;
    public GameObject[] bulletPrefabs;
    public GameObject spawnPoint;
    public GUIManager guiManager;

    // Update is called once per frame
    void Update()
    {
        //Rotate the cannon based on mouse position
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 direction = mousePos3D - transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(angle - 90) < 48)
        {
            transform.rotation = Quaternion.Euler(0, 0, (angle - 90));

        }


        //Fire bullets based on key presses
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(guiManager.OneCount > 0)
            {
                FireBullet(0, 1);
                guiManager.BulletWasShot(1);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (guiManager.TwoCount > 0)
            {
                FireBullet(1, 2);
                guiManager.BulletWasShot(2);
            }
                
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (guiManager.ThreeCount > 0)
            {
                FireBullet(2, 3);
                guiManager.BulletWasShot(3);
            }

        }
    }

    private void FireBullet(int index, int value)
    {
        GameObject bullet = Instantiate(bulletPrefabs[index], spawnPoint.transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().SetValue(value);
        bullet.GetComponent<Rigidbody>().AddForce(transform.up * 20f, ForceMode.Impulse);
    }

}

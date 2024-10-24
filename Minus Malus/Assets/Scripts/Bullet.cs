using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Inscribed")]
    public int Value = 0;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
        {
            Crate crate = collision.gameObject.GetComponent<Crate>();
            crate.ApplyDamage(Value);
            Destroy(gameObject); // Destroy the bullet after it hits a crate
        }
    }

    public void SetValue(int value)
    {
        this.Value = value;
    }


}

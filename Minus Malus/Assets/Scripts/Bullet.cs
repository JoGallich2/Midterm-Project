using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Inscribed")]
    public int Value;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
        {
            Crate crate = collision.gameObject.GetComponent<Crate>();
            Destroy(gameObject); // Destroy the bullet after it hits a crate
            crate.ApplyDamage(Value);
            
        }
    }

    public void SetValue(int value)
    {
        this.Value = value;
    }


}

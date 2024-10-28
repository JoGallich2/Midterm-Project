using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crate : MonoBehaviour
{
    [Header("Inscribed")]
    public float screenBoundsx = 8.6f;
    private ScoreManager scoreManager;
    public TMP_Text valueText;
    public float rotationSpeed = 2f; // how fast the crate rotates
    public float maxRotationAngle = 10f; // Maximum rotation angle in degrees

    [Header("Dynamic")]
    public int crateValue;
    public int pointsOnSuccess = 10;
    public int pointsOnFail = -5;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        // Initialize the text with the current crate value
        UpdateText();
    }

    public void ApplyDamage(int damage)
    {
        crateValue -= damage;
        if (crateValue == 0)
        {
            //If successful amount of damage is reached add points and destroy crate
            scoreManager.AddPoints(pointsOnSuccess);
            Destroy(gameObject);
            UpdateText();
        }
        else if (crateValue < 0)
        {
            //If not successful amount of damage is reached remove points and destroy crate
            scoreManager.AddPoints(pointsOnFail);
            Destroy(gameObject);
            UpdateText();
        }
        else if (crateValue > 0)
        {
            UpdateText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime); // Move crate downards

        // Rotate the crate side to side
        float rotationY = Mathf.Sin(Time.time * rotationSpeed) * maxRotationAngle;
        float rotationZ = Mathf.Sin(Time.time * rotationSpeed) * maxRotationAngle;
        transform.rotation = Quaternion.Euler(0, rotationY, rotationZ);

        if (transform.position.y < -0.5f)
        {
            scoreManager.AddPoints(pointsOnFail);
            Destroy(gameObject);
        }
    }

    private void UpdateText()
    {
        valueText.text = crateValue.ToString();
    }

}

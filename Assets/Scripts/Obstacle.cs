using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float rotationSpeed;
    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);

            GameManager.instance.GameOver();
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            GameManager.instance.incrementScore();
            Destroy(gameObject);
        }
    }
}

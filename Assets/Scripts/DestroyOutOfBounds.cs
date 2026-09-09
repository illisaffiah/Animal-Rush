using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30f;
    public float lowerBound = -10f;

    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            // Print Game Over to the console if an animal gets past the player
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
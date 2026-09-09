using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private ScoreManager scoreManager;
    public AudioClip hitSound;

    void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreManager.AddScore(1);

        // Play the hit sound at the location of the collision
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10f;
    public float xRange = 17f;

    public GameObject projectilePrefab;

    public AudioClip shootSound;
    private AudioSource playerAudio;

    void Start()
    {
        // Get the AudioSource component attached to the Player
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            // Play the shooting sound once
            playerAudio.PlayOneShot(shootSound, 1.0f);
        }
    }
}
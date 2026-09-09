using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40f;

    void Start()
    {
    }

    void Update()
    {
        // Move forward along the Z axis
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
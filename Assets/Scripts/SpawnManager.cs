using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //array to store animals prefab
    public GameObject[] animalPrefabs;
    public int animalIndex;
    
    public float startDelay = 2;
    public float spawnInterval = 1.5f;

    void Start()
    {
        //this method will be called at 2 seconds and will be called every 1.5 s
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        //produce a random number between 0 - the length of the prefabs
        animalIndex = Random.Range(0, animalPrefabs.Length);

        //spawn an animal in element 0, place it at 20 on the z axis with default rotation
        Instantiate(animalPrefabs[animalIndex], new Vector3(Random.Range(-20, 20), 0, 20), animalPrefabs[animalIndex].transform.rotation);
    }
}
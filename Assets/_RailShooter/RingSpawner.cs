using System.Collections;
using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate;
    public float spawnSubstract;
    public float spawnRateLimit;
    public Transform moverPosition;
    public float minRandomX;
    public float maxRandomX;
    public float minRandomY;
    public float maxRandomY;

    private void Awake()
    {
        Instantiate(prefab, new Vector3(0, 0.75f, -8), Quaternion.identity);
        StartCoroutine(ringSpawn());
    }


    IEnumerator ringSpawn()
    {
        if (spawnRate != spawnRateLimit)
            spawnRate -= spawnSubstract;
        if(spawnRate < spawnRateLimit)
            spawnRate = spawnRateLimit;
        yield return new WaitForSeconds(spawnRate);
        Instantiate(prefab, new Vector3(Random.Range(minRandomX, maxRandomX),
                                        Random.Range(minRandomY, maxRandomY),
                                        moverPosition.position.z + 10), Quaternion.identity);
        StartCoroutine(ringSpawn());
    }
}

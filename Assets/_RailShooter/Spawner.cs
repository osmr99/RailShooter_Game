using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform mover;
    private bool canSpawn = false;
    public int count;
    public int count2;
    public int offSet;

    private void Awake()
    {
        Instantiate(prefab);
    }

    private void FixedUpdate()
    {
        if (mover.position.z >= offSet / 2 * (count + count2) && !canSpawn)
        {
            canSpawn = true;
            spawnMap();
        }
    }

    public void spawnMap()
    {
        count++;
        count2++;
        Instantiate(prefab, new Vector3(0, 0, offSet * (count - 1)), Quaternion.identity);
        canSpawn = false;
    }
}

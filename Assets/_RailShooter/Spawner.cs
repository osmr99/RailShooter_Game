using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform mover;
    public Transform pillars;
    private bool canSpawn = false;
    public int count;
    public int offSet;

    private void FixedUpdate()
    {
        if(mover.position.z >= offSet * count && !canSpawn)
        {
            canSpawn = true;
            spawnMap();
        }
    }

    public void spawnMap()
    {
        count++;
        pillars.position = new Vector3(0, 0, offSet * (count - 1));
        canSpawn = false;
    }
}

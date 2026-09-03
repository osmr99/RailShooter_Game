using UnityEngine;

public class KillScript : MonoBehaviour
{
    public float killTime;
    float timeElapsed = 0f;

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > killTime)
        {
            Destroy(gameObject);
        }    
    }
}

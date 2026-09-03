using UnityEngine;

public class KillScript : MonoBehaviour
{
    public float killTime = 2f;
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

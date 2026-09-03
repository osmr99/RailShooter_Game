using UnityEngine;

public class RingScript : MonoBehaviour
{
    public GameObject ringMesh;
    public Vector3 rotateSpeed;

    private void Update()
    {
        ringMesh.transform.Rotate(rotateSpeed * Time.deltaTime);
    }

    //private void OnCollisionEnter(Collision col)
    //{
        //if(col.gameObject.tag == "Player")
        //{
            //Destroy(gameObject);
            // And add sfx
        //}
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            // And add sfx
        }
    }
}

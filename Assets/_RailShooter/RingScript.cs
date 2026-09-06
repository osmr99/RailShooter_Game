using UnityEngine;

public class RingScript : MonoBehaviour
{
    public GameObject ringMesh;
    public Vector3 rotateSpeed;
    public SoundManager sfxManager;
    public AudioClip ringSfx;
    float timeElapsed = 0f;
    float aliveTime = 10f;

    private void Start()
    {
        sfxManager = FindAnyObjectByType<SoundManager>();
    }

    private void Update()
    {
        ringMesh.transform.Rotate(rotateSpeed * Time.deltaTime);

        timeElapsed += Time.deltaTime;
        if (timeElapsed > aliveTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            sfxManager.PlaySound3D(ringSfx, transform.position);
            Destroy(gameObject);
        }
    }
}

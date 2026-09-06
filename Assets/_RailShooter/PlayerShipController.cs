using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    private float horizontalInput, verticalInput;

    [Header("Clamping")]
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    [Header("Move and Tilt")]
    public float moveSpeed;
    public float tiltSpeed;
    public float tiltAngle = 30;
    Vector3 tilting;

    [Header("Shoot Projectile")]
    public Rigidbody playerProjectile;
    public Transform[] shotSpawns;
    public bool canShoot;

    [Header("Sound Stuff")]
    public SoundManager sfxManager;
    public AudioClip blastSfx;

    public bool isInverted;

    private void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        //if(EditorApplication.isPlaying && Input.GetKeyDown(KeyCode.Escape))
            //EditorApplication.isPlaying = false;

        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        HandleTilting();

        if(Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            Rigidbody _shot;
            foreach (Transform t in shotSpawns)
            {
                _shot = Instantiate(playerProjectile, t.position, t.rotation) as Rigidbody;
                _shot.AddForce(t.forward * 500);
                sfxManager.PlaySound3D(blastSfx, transform.position);
            }
            StartCoroutine(ResetShot());
        }
    }


    IEnumerator ResetShot()
    {
        yield return new WaitForSeconds(0.25f);
        canShoot = true;
    }

    private void FixedUpdate()
    {
        Movement();
        ClampToScreen();
    }

    void Movement()
    {
        if (isInverted)
            verticalInput *= -1;
        Vector3 _movement = new Vector3(horizontalInput, verticalInput, 0);
        transform.position += _movement * moveSpeed * Time.deltaTime;
    }

    void HandleTilting()
    {
        TiltZ(horizontalInput);
        TiltX(verticalInput);
    }

    void TiltZ(float axis)
    {
        Vector3 targetEulerAngle = transform.localEulerAngles;

        transform.localEulerAngles = new Vector3(targetEulerAngle.x,
            Mathf.LerpAngle(targetEulerAngle.y, axis * tiltAngle, tiltSpeed),
            Mathf.LerpAngle(targetEulerAngle.z, -axis * tiltAngle, tiltSpeed));
    }

    void TiltX(float axis)
    {
        if(isInverted) axis *= -1;
        Vector3 targetEulerAngle = transform.localEulerAngles;

        transform.localEulerAngles = new Vector3(Mathf.LerpAngle
            (targetEulerAngle.x, -axis * tiltAngle, tiltSpeed), targetEulerAngle.y,
            targetEulerAngle.z);
    }

    void ClampToScreen()
    {
        Vector3 _position = transform.position;
        _position.x = Mathf.Clamp(_position.x, xMin, xMax);
        _position.y = Mathf.Clamp(_position.y, yMin, yMax);
        transform.position = _position;
    }
}

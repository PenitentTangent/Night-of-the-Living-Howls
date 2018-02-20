using UnityEngine;
using System.Collections;

public class CameraFollower1 : MonoBehaviour {

    public Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public float shakeTimer;
    public float shakeAmount;

    public GameObject player;
    public Renderer background;

    private float rightBound;
    private float leftBound;
    private float topBound;
    private float bottomBound;

    void Start()
    {
        float cameraVertExtent = Camera.main.orthographicSize;
        float cameraHorzExtent = cameraVertExtent * Camera.main.aspect;

        float backgroundVertExtent = background.bounds.size.y / 2.0f;
        float backgroundHorzExtent = background.bounds.size.x / 2.0f;


        /* DEBUG STATEMENTS
        Debug.Log("CameraVertExtent: " + cameraVertExtent);
        Debug.Log("cameraHorzExtent: " + cameraHorzExtent);
        Debug.Log("backgroundVertExtent: " + backgroundVertExtent);
        Debug.Log("backgroundHorzExtent: " + backgroundHorzExtent);
        */

        rightBound = backgroundHorzExtent - cameraHorzExtent;
        leftBound = -1 * rightBound;
        topBound = backgroundVertExtent - cameraVertExtent;
        bottomBound = -1 * topBound;

    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
     
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBound, rightBound),
            Mathf.Clamp(transform.position.y, bottomBound, topBound),
            transform.position.z);

        if (shakeTimer >= 0)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;

            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);

            shakeTimer -= Time.deltaTime;
        }
    }

    public void ShakeCamera(float shakePwr, float shakeDur)
    {
        shakeAmount = shakePwr;
        shakeTimer = shakeDur;
    }
}
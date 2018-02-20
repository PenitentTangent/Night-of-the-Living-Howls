using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

    public Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public float shakeTimer;
    public float shakeAmount;

    public GameObject player;
    public GameObject background;
    //private SpriteRenderer spriteBounds;

    private float rightBound;
    private float leftBound;
    private float topBound;
    private float bottomBound;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

    void Start()
    {
        //float vertExtent = Camera.main.orthographicSize;
        //loat horzExtent = vertExtent * Screen.width / Screen.height;

        //spriteBounds = background.GetComponentInChildren<SpriteRenderer>();
    
		/*
        leftBound = (float)(horzExtent - spriteBounds.sprite.bounds.size.x / 2.0f);
        rightBound = (float)(spriteBounds.sprite.bounds.size.x / 2.0f - horzExtent);
        bottomBound = (float)(vertExtent - spriteBounds.sprite.bounds.size.y / 2.0f);
        topBound = (float)(spriteBounds.sprite.bounds.size.y / 2.0f - vertExtent);
        */

    }

    void FixedUpdate()
    {
     
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);



        //posX = Mathf.Clamp(posX, leftBound, rightBound);
        //posY = Mathf.Clamp(posY, bottomBound, topBound);

        transform.position = new Vector3(posX, posY, transform.position.z);

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
			Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
			Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));

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
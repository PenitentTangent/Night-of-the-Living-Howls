using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour{

	private GameObject player;

	public Vector2 velocity;
	public float smoothTimeY;
	public float smoothTimeX;

	public float speed;

    private float lastX;
    private float lastY;

    private Animator anim;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");


	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        //float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        Vector2 previousVector = transform.position;
		//float posX = player.transform.position.x;
		//float posY = player.transform.position.y;

		transform.position = Vector2.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
        //new Vector3(posX, posY, transform.position.z);
        

		
	}

    void UpdateAnimation(Vector3 dir)
    {

        if (dir.x == 0f && dir.y == 0f)
        {
            //if we are idle, then execute idle animation
            anim.SetFloat("LastDirX", lastX);
            anim.SetFloat("LastDirY", lastY);
            anim.SetBool("Movement", false);
        }
        else
        {
            lastX = dir.x;
            lastY = dir.y;
            anim.SetBool("Movement", true);
        }

        anim.SetFloat("DirX", dir.x);
        anim.SetFloat("DirY", dir.y);
    }


}



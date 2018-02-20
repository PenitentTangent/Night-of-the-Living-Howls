using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NightmareMonster : MonoBehaviour, IInteractable {

    Animator anim;
    public GameObject player;
    public new CameraFollower camera;
    public float speed;
    public float distance;



	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if ((distance < 15) && (speed > 0))
        {
            camera.ShakeCamera(1, 20);
            StartCoroutine("Chase");
        }
	}

    IEnumerator Chase()
    {
        while (distance > 5.03)
        {
            //Handheld.Vibrate();
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            Debug.Log("distance: " + distance);
            yield return null;
        }

        speed = 0;
        camera.ShakeCamera(0, 0);
        anim.SetInteger("State", 1);

    }

    public void Interact()
    {
		
    }
}

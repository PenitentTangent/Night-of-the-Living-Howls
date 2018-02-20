using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfLight : MonoBehaviour {

	private GameObject player;
	private GameObject playerLight;
	private float pDist; //distance from player
	public float lightRange = 0.5f;
	private Material wolfMat;
	public float factor = 2f; //constant to adjust alpha fade out
	private float lampDist; //distance from lamp

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerLight = GameObject.FindGameObjectWithTag ("playerLight");
	}
	
	// Update is called once per frame
	void Update () {
		pDist = Vector2.Distance(transform.position, player.transform.position);

			//dist = lightRange;

		//wolfMat = GetComponent<Renderer>().material;

		Color tmp = GetComponent<SpriteRenderer>().color;
		/*
		if (pDist < lightRange) {
			tmp.a = 1f;
		} else if (pDist < (lightRange*4) || pDist > lightRange) {
			float expo = (factor * pDist * pDist);
			tmp.a = (lightRange / expo);
		} else{
			tmp.a = 0f;
		}
		*/
		//Debug.Log ("lightrange = " + lightRange);
		//Debug.Log ("dist = " + pDist);

		lampDist = gameObject.transform.position.x;
		if (lampDist > -11 && lampDist < 11) {
			tmp.a = ((Mathf.Abs (lampDist) / 11) * (Mathf.Abs (lampDist) / 11) * (Mathf.Abs (lampDist) / 11)); //light fade is cubed
			if (pDist < lightRange && playerLight.GetComponent<Light> ().enabled == true) { //checks if player point light is on
				tmp.a += 0.75f; //see them in your torch range
			} else {
				
			}
		}

		GetComponent<SpriteRenderer>().color = tmp;

	}
}

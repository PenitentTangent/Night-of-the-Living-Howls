using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pCooldown : MonoBehaviour {

	public Image cooldownBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float playerPosX = gameObject.transform.position.x;
		float playerPosY = gameObject.transform.position.y;
		cooldownBar.transform.position = new Vector2 (playerPosX, playerPosY+2);
		//Vector3 barPos = Camera.main.WorldToScreenPoint (this.transform.position);
		//cooldownBar.transform.position = barPos;

	}
}

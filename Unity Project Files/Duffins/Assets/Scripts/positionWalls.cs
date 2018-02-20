using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionWalls : MonoBehaviour {

	//I don't think this script is necessary! The walls don't move around with resolution change, just the camera width/ height.
	//Need a different script to adjust camera clamping positions based on resolution.

	GameObject topWall;
	GameObject bottomWall;
	GameObject leftWall;
	GameObject rightWall;

	// Use this for initialization
	void Start () {
		topWall = GameObject.FindGameObjectWithTag ("top");
		bottomWall = GameObject.FindGameObjectWithTag ("bottom");
		leftWall = GameObject.FindGameObjectWithTag ("left");
		rightWall = GameObject.FindGameObjectWithTag ("right");
	}

	// Update is called once per frame
	void Update () {
		/*
		Vector3 top = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height, 0));
		topWall.transform.position = top;

		Vector3 bottom = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 0, 0));
		bottomWall.transform.position = bottom;

		Vector3 left = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height/2, 0));
		leftWall.transform.position = left;

		Vector3 right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height/2, 0));
		rightWall.transform.position = right;
		*/
	}
}

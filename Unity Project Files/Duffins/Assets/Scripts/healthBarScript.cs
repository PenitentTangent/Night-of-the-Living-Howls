using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarScript : MonoBehaviour {

	private GameObject player;

	public float fill;




	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		
	}
	
	// Update is called once per frame
	void Update () {

		float currentHealth = player.GetComponent<PlayerController> ().GetHealth ();
		float maxHealth = player.GetComponent<PlayerController>().maxHealth;

		fill = currentHealth / maxHealth;

		GetComponent<Image> ().fillAmount = fill;
		
	}
}

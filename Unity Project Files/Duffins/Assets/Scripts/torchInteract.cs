using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchInteract : MonoBehaviour, IInteractable {


	// Use this for initialization
	void Start () {

	}

	public void Interact(){

		Destroy (gameObject);

	}


	// Update is called once per frame
	void Update () {

	}
}

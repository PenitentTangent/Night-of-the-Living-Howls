using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchSpawner : MonoBehaviour, IInteractable {

	public GameObject torch;
	public float spawnDelay = 5f;
	//public float spawnTime = 0.3f;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		//instantiate enemies
		Invoke("Spawn", spawnDelay);

	}

	public void Interact(){
		Invoke("Spawn", spawnDelay);

	}

	// Update is called once per frame
	void Spawn () {
		//every x seconds, instantiate more enemies

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (torch, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
}

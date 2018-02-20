using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

	public GameObject enemy;
	public float startDelay = 0f;
	public float spawnTime = 0.3f;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		//instantiate enemies
		InvokeRepeating("Spawn", startDelay, spawnTime);

	}
	
	// Update is called once per frame
	void Spawn () {
		//every x seconds, instantiate more enemies

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
}

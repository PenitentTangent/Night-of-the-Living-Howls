using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaSetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        GetComponent<SpriteRenderer>().color = tmp;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

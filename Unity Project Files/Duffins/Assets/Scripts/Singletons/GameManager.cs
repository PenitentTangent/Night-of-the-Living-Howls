using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.SceneManagement; //this lets me reload scene below

public class GameManager : MonoBehaviour
{
    

	public static GameManager instance = null;

    public GameObject player;


    void Awake()
	{
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
		DontDestroyOnLoad(gameObject);

        player = GameObject.FindGameObjectWithTag("Player");

        InitGame();
	}

	//Initializes the game for each level.
	void InitGame()
	{
	
	}



	//Update is called every frame.
	void Update()
	{

	}

    public void OnPlayerDeath()
    {
        SceneManager.LoadScene("EndMenu");
    }
}
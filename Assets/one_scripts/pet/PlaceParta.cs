using UnityEngine;
using System.Collections;

public class PlaceParta : MonoBehaviour {

	public float animalHealth;

	public float spawnTime = 6f;   

	public GameObject caps;
	public int[] enemyCount;
//	public int maxEnemies = 5;

	public GameObject[] Body;


	//public gu


	// Use this for initialization
	void Start () {

		//petText.text = " Hi, I am your virtual PET. Press E to hear about my free fall ";
	

		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		//enemyCount = new int[maxEnemies];
		//caps.transform.position = Body [3].transform.position;

	}

	void update(){
		if(Input.GetKeyDown(KeyCode.Space)) 
			Application.LoadLevel("allat1");

		StartStory ();
	}

	void Spawn ()
	{
	
		int spawnPointIndex = Random.Range (0, Body.Length);
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (caps, Body[spawnPointIndex].transform.position, Body[spawnPointIndex].transform.rotation);
	}

	void StartStory (){
}

	void changeLevel () {

		if(Input.GetKeyDown(KeyCode.E)) 
			Application.LoadLevel("allat1");
	}
	
}
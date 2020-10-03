using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour {

	public GameObject bodyPart;
	public int[] bodyPartCount;
	public int maxBodyParts = 5;

	public Transform[] BodyPos;
	// Use this for initialization
/*	void Start () {

		bodyPartCount = new int[maxBodyParts]; 
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		for (int numberOfEnemies = 0; numberOfEnemies <= maxBodyParts; numberOfEnemies++)
		{
			GameObject enemyCombatantClone = Instantiate(bodyPart, new Vector3(40, 2, 0), Quaternion.identity) as GameObject;
		}
	}*/
}
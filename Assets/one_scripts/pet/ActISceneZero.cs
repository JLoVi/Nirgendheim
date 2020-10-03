using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActISceneZero : MonoBehaviour {
	
    /// <summary>
    /// act one scene zero manager
    /// </summary>
	public Text txt;
	
	public bool change= true;

	public GameObject part;
	//public GameObject cam;
	// Use this for initialization
	void Start () {
		
		//StartCoroutine("MyEvent");
	}
	
	// Update is called once per frame
	void Update () {
		//cam.transform.Rotate(Vector3.up * Time.deltaTime);

		Invoke ("AddGravity", 15);

		Invoke ("FreeFall", 25);
			

	}
	
	private IEnumerator MyEvent()
	{
		
		if (change = true) {
			
			
			yield return new WaitForSeconds (10f);
			
			txt.text = "  ";
			
			yield return new WaitForSeconds (10f);
			
			txt.text = "  Hey.. what are you doing to your pet? press the button finally. ";
			yield return new WaitForSeconds (10f);
			
			txt.text = "  ";
			
			yield return new WaitForSeconds (2f);
			
			txt.text = "  khm...E ? ";
			
			yield return new WaitForSeconds (5f);
			
			txt.text = "  ";
			
			change = false;
			
			
			
		}
		
	}
	
	void FreeFall() {
		
		Application.LoadLevel ("ActIScene1");
	}
	void AddGravity() {
		
		 // Make a new GO.
		Rigidbody gameObjectsRigidBody = part.AddComponent<Rigidbody>(); 
	}
	
	
}

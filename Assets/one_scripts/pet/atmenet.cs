using UnityEngine;
using System.Collections;

public class atmenet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("LeveLoad", 20);

    }


    void LeveLoad ()
    {
        Application.LoadLevel("allat");
    }

    
}

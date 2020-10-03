using UnityEngine;
using System.Collections;

public class DisableSound : MonoBehaviour {

    public GameObject SoundActI;
	// Use this for initialization
	void Start () {
        if (GameObject.Find("sound") != null)

            SoundActI.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

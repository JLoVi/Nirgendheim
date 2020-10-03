using UnityEngine;
using System.Collections;

public class respawn : MonoBehaviour {

    public int rtime = 5;
    void OnCollisionEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;

        Invoke("Respawn", rtime);

    }

    void Respawn()
    {
        this.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<MeshRenderer>().enabled = true;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

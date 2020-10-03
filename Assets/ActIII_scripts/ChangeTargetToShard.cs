using UnityEngine;
using System.Collections;

public class ChangeTargetToShard : MonoBehaviour {

    public navmesh targetscript;
    public Transform finalDestsshard;
    // Use this for initialization
    void Start () {
        targetscript = FindObjectOfType<navmesh>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        if (targetscript.target = gameObject.transform) { 
        targetscript.target = finalDestsshard;
        }
    }
}

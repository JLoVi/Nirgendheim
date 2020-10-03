using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class calltofindpub : MonoBehaviour {

    public GameObject instructionPanel;
    public Text instructiontxt;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter()
    {
        instructionPanel.SetActive(true);
        instructiontxt.text = " A FEW PEOPLE HAVE BEEN SITTING AT HERE, AT THE UNFINISHED STATION. TRY TO FIND THEM.";
    }

    void OnTriggerExit()
    {
        instructiontxt.text = " ";
        instructionPanel.SetActive(false);
        
    }
}

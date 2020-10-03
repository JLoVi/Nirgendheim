using UnityEngine;
using System.Collections;

public class CallToCross : MonoBehaviour {

    public Animator ani;
    //maybe sound effect

    public AudioSource audio;

    public AudioClip callToCross;

    public AudioClip ablakfel;

    public TextBoxManager theTextBox;

    public GameObject doorToOpen;

    public int InvokeTime;
    // Use this for initialization
    void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();

        ani.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter() { 

   
        Invoke("CallForWater", 15);
        
    
    }

    
    void OntriggerExit()
    {
        //theTextBox.instructionText.text = " ";

        //invokeal kikapcsolni az objektet

    }

void CallForWater()
    {
        //theTextBox.EnableBox(theTextBox.instructionBox);

        //play callforwatersound 760s
        ask(ablakfel);
        // theTextBox.instructionText.text = "Try to get some water from the vending machine on the other side"; ///here audio pet mondja
        ani.enabled=true;
        ask(callToCross);
    }

    void ask(AudioClip aud)
    {

        audio.PlayOneShot(aud);
        //GetComponent<AudioSource> ().PlayOneShot (aud);

    }


}

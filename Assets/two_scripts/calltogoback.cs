using UnityEngine;
using System.Collections;

public class calltogoback : MonoBehaviour {
   // public TextBoxManager theTextBox;
   // public int InvokeTime;
    public GameObject fireevent;
    // Use this for initialization

    public AudioSource audioso;

    public AudioClip callToFireAud;

    void Start () {
       // theTextBox = FindObjectOfType<TextBoxManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        fireevent.SetActive(false);
        Invoke("CallForFire", 20);
        Invoke("CallForFire", 25);
    }
    void CallForFire() //kesobb
    {
        //  theTextBox.EnableBox(theTextBox.instructionBox);
        audioso.PlayOneShot(callToFireAud);
        //   theTextBox.instructionText.text = "It's getting cold. Time to go back to the fire"; ///here audio pet mondja

    }
}

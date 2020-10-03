using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardEvents : MonoBehaviour {

    // public TextBoxManager theTextBox;
    // Use this for initialization

    public AudioSource audioso;

    public AudioClip cardnarrationone;
  
  
   

   
    public GameObject cardButton;


  
    public GameObject instructionpanel;
    public Text instructionTxt;

    public GameObject chrono;
    public GameObject head;

    public GameObject inputFieldtodis;

    public GameObject goBackTrigger;

    public GameObject objectsToDisable;
    public GameObject[] objectsToEnable;
    public bool bent = false;

    public bool kint = false;

    public GameObject portal;
    private bool hasPlayed = false;

    void Start () {
        //theTextBox = FindObjectOfType<TextBoxManager>();
        //sest everything to false if not working
        bent = false;


        chrono.SetActive(false);
        cardButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
        if (bent == true && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            ViewCard();
        }
	}

    void OnTriggerEnter()
    {
        
        bent = true;

        if (!hasPlayed) {
        cardButton.SetActive(true);
    
        if (head.activeSelf == true)
        {
            head.SetActive(false);
        }
        }
        hasPlayed = true;
        //theTextBox.EnableBox(theTextBox.answerBox);

    }

    void OnTriggerExit()
    {
       // theTextBox.EnableBox(theTextBox.instructionBox);
      //  theTextBox.instructionText.text = "The card is yours now. Keep it safe";
        chrono.SetActive(false);
        //theTextBox.DisableBox(theTextBox.answerBox);
        instructionpanel.SetActive(true);
        instructionTxt.text = "TTHE CARD IS YOURS NOW. KEEP IT SAFE";

        goBackTrigger.SetActive(true);

       
        Invoke("DisableInstructions", 8);
        portal.SetActive(false);
        kint = true;
        
        ///elkezd esni
        
    }

    public void ViewCard()
    {

        //play card sound!!! fontos!!!!! 67 69 vagy 73

        // show card image
        if (chrono.activeSelf == false) { 
            chrono.SetActive(true);
    }

        cardButton.SetActive(false);

        //start invoke to call to the other side (lots of time so you can go see the object if you havent done so already
       

      
            ask(cardnarrationone);
            //destroy shitloads of stuff on the other side (powerful card man)
            if (objectsToDisable.activeSelf == true) {
        objectsToDisable.SetActive(false);
        }
        foreach (GameObject objecti in  objectsToEnable){
            if(objecti.activeSelf == false) {
       objecti.SetActive(true); //location edited
            }
        }
    }
    void ask(AudioClip aud)
    {

        audioso.PlayOneShot(aud);
        //GetComponent<AudioSource> ().PlayOneShot (aud);

    }

    void DisableInstructions()
    {
        instructionTxt.text = " ";
        instructionpanel.SetActive(false);
    }






}

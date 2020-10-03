using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class chronosTrigger : MonoBehaviour {
    public AudioSource audioso;

    public AudioClip approachingDev;

    public AudioClip tunnelspawn;

    public GameObject button;
 
    public Text buttontxt;

    public GameObject instructionPanel;
    public Text instructiontxt;

    public GameObject portal;

    public bool chronosbent = false;

    public GameObject head;

    public bool hasplayedOnObj = false;

    public GameObject simacard;

    // Use this for initialization
    void Start () {
        chronosbent = false;
        portal.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (chronosbent == true && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            MakePortal();
        }

    }

    void OnTriggerEnter()
    {
        //step inside the object felirat says
        chronosbent = true;
        //use chronos trigger felirat says

        if (!hasplayedOnObj)
        {
            if (button.activeSelf == false)
            {
                button.SetActive(true);
            }
        }
        hasplayedOnObj = true;

        Destroy(simacard);
        Destroy(head);



        ask(approachingDev);

        }

    void ask(AudioClip aud)
    {

        audioso.PlayOneShot(aud);
        //GetComponent<AudioSource> ().PlayOneShot (aud);

    }

   public void MakePortal()
    {
        ask(tunnelspawn);
        button.SetActive(false);
        portal.SetActive(true);
        instructionPanel.SetActive(true);
        instructiontxt.text = " YOU ACTIVATED A TUNNEL";
        simacard.SetActive(false);
        
    }
}

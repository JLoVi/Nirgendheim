using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class chronosTrigger : MonoBehaviour
{
    public AudioSource audioso;

    public AudioClip approachingDev;

    public AudioClip tunnelspawn;

  //  public GameObject button;

    public Text buttontxt;

    public GameObject instructionPanel;
    public Text instructiontxt;

    public GameObject portal;

    public bool chronosbent = false;

    public GameObject head;

    public bool hasplayedOnObj = false;

//   public GameObject simacard;

    // Use this for initialization
    void Start()
    {
        chronosbent = false;
        portal.SetActive(false);
        buttontxt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (chronosbent == true && Input.GetKeyDown(GamepadController.instance.controlList.submitControl))
        {
            MakePortal();
        }

    }

    void OnTriggerEnter()
    {
        //step inside the object felirat says
        chronosbent = true;
        //use chronos trigger felirat says

        if (buttontxt.gameObject.activeSelf == false)
        {
            buttontxt.gameObject.SetActive(true);
            string s = string.Format(" PRESS  <color=#00ff00ff>{0}</color> TO USE YOUR CHRONOS CARD WITH THE OBJECT", GamepadController.instance.controlList.submitName);
            buttontxt.text = s;
        }

//        Destroy(simacard);
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
        buttontxt.gameObject.SetActive(false);
        portal.SetActive(true);
        instructionPanel.SetActive(true);
        instructiontxt.text = " YOU ACTIVATED A TUNNEL";
//        simacard.SetActive(false);

    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AskForId : MonoBehaviour
{

    // public TextBoxManager theTextBox;

    public AudioSource audioso;

    public AudioClip borderaud;

    public GameObject inputpanel;
    public GameObject inputelements;

    public Text inputInstructions;

    public GameObject fej;
    public GameObject card;
    public GameObject inputtosetactive;

    public GameObject fenwhole;
    public GameObject fenbroken;

    public string idNumber;

    public InputField input;
    // Use this for initialization
    void Start()
    {
        inputelements.SetActive(false);
        inputpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        idNumber = ActISceneTwo.iDNum.ToString();
        //Debug.Log(input.text);
        if(NirgenManager.instance.wasPaused == true)
        {
    //        Debug.Log("was paused");
            input.ActivateInputField();

        }
        if (input.text == idNumber)
        {
            Debug.Log("you can pass");
            fenbroken.SetActive(true);
            fenwhole.SetActive(false);
            inputInstructions.text = "YOU CAN PASS!" + ActISceneThree.yourName;
        }
        else
        {
          //  Debug.Log("incorrect id");
        }
    }
    void OnTriggerEnter(Collider other)
    { 
        if (other.name == "FPSController")
        {
            audioso.PlayOneShot(borderaud);
            inputpanel.SetActive(true);
            inputelements.SetActive(true);


            fej.SetActive(false);
            card.SetActive(false);
            inputtosetactive.SetActive(true);
            input.ActivateInputField();
           // inputInstructions.text = " ID REQUIRED. Press OPTIONS if you need to view your ID again" + ActISceneThree.yourName ;
            string s = string.Format("ID REQUIRED. Press <color=#00ff00ff>{0}</color> if you need to view your ID again", GamepadController.instance.controlList.mainMenuButton);
            inputInstructions.text = s;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSController")
        {
            
            inputelements.SetActive(false);
            inputpanel.SetActive(false);
            inputInstructions.text = " ";
            
            input.text = "";

            if (fenbroken.activeSelf == true) {
                fenbroken.SetActive(false);
            }

            if (fenwhole.activeSelf == false)
            {
                fenwhole.SetActive(true);
            }
        }
    }
}

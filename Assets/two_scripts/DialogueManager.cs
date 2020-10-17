using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {



    public GameObject dialogueBox;

   

    public Text dialogueText;


    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;


    public bool isActive;
    public CharacterController player;

    public bool stopPlayerMovement;

    public bool isTyping;

    public bool cancelTyping;

    public float typeSpeed;


	// Use this for initialization
	void Start () {

        

        player = FindObjectOfType<CharacterController>();
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        if (endAtLine == 0 )
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }

        if (!isActive)
        {
            DisableTextBox();
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (!isActive)
        {
            return;
        }
     //   dialogueText.text = textLines[currentLine];
        

        if (Input.GetKeyDown(GamepadController.instance.controlList.dialoogueXcontrol))
        {

            if(!isTyping) { 
                currentLine += 1;
            
                if (currentLine >= endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }

            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }





    }

    private IEnumerator  TextScroll(string LineOfText)
    {
        int letter = 0;
        dialogueText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping &&(letter < LineOfText.Length -1))
        {
            dialogueText.text += LineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        dialogueText.text = LineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
       
        dialogueBox.SetActive(true);
        isActive = true;

        player.enabled = false;
        StartCoroutine(TextScroll(textLines[currentLine]));
    }
    public void DisableTextBox()
    {
        dialogueBox.SetActive(false);
       
        player.enabled = true;

        isActive = false;
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}

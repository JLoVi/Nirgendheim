using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{

    public GameObject instructionBox;

    public Text instructionText;
    //
    public GameObject inputimgBox;

    public Text inputText;
    //
    public GameObject textBox; //dialogue and info box

    public Text theText;
    //
    public GameObject answerBox;

    public Button[] answerText;
    //
    public TextAsset textFile;
    public string[] textLines;

    public string instructionLine;

    public int currentLine;
    public int endAtLine;

    public CharacterController player;

    public bool isActive;


    public bool stopPlayerMovement;

    //4autotype
    private bool isTyping = false;
    private bool cancelTyping = false;

    public bool enableEvent;

    public float typeSpeed;


    public bool reachedEndLine;

    /// <summary>
    /// other canvas stuff
    /// </summary>
    /// 

    public GameObject mainCanvas;

    public GameObject pausedCanvas;

    public Text pausedMenutext;

    public bool isPaused;

    public GameObject chrono;
    public GameObject headimg;

    void awake()
    {
      

    }

    // Use this for initialization
    void Start()
    {
       
        pausedCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        
        player = FindObjectOfType<CharacterController>();

        DisableBox(textBox);
        DisableBox(inputimgBox);
        DisableBox(answerBox);
        DisableBox(instructionBox);
        chrono.SetActive(false);
        headimg.SetActive(false);


        if (ActISceneTwo.iDNum == 0)
        {
            ActISceneTwo.iDNum = 1234567;//ide az en id-m
        }
        pausedMenutext.text = "ID: " + ActISceneTwo.iDNum;
        //+ "\n" + "The events you will be activating happened outside of this space and at a different time." + "\n" + " However they are driving the game, creating quests and options." + "\n" + " Press [sqare] to activate, [x] to read through.";
    }
    public void DisableBox(GameObject boxToDisable)
    {
        boxToDisable.SetActive(false);

    }

    public void DeactivateInstructionBox()
    {
        if (instructionBox.activeSelf == true && Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            instructionText.text = " ";
            instructionBox.SetActive(false);
        }
    }
    void Update()
    {
        if (isPaused)
        {
            PauseGame(true);
            if (chrono.activeSelf== true)
            {
                chrono.SetActive(false);
            }
            PauseGame(true);
            if (headimg.activeSelf == true)
            {
               headimg.SetActive(false);
            }
        }
        else
        {
            PauseGame(false);
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            SwitchPause();
        }


    }

    void PauseGame(bool state)
    {
        if (state)
        {

            Time.timeScale = 0.1f; //paused
        }

        else
        {
            Time.timeScale = 1.0f; //unpaused
        }

        pausedCanvas.SetActive(state);
        mainCanvas.SetActive(!state);
    }

    public void SwitchPause()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }


   



}


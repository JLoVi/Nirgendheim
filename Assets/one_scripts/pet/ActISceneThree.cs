using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActISceneThree : MonoBehaviour {


    /// <summary>
    /// act I scene III optional
    /// </summary>
	public AudioClip askname;

	public AudioClip typename;

	public AudioClip realname;

    public AudioClip hello;
    public AudioClip iampet;
    public AudioClip changeform;
    public AudioClip welcome;
    public AudioClip followlead;
    public AudioClip willbeyours;

    public AudioClip notsure;
    public AudioClip attempt;
    public AudioClip continueif;



    public int steps = 4;
	

	public Text txt;

    public Text instructions;
    public Text gameover;

    public GameObject yesno;
    public GameObject inputField;
    public InputField input;
    InputField.SubmitEvent se;

	public string tx;

	public GameObject part;

	public bool change= true;

    public bool yes;
    public bool no;

    public bool continueGame;
    public bool coroutineStarted;

    public static string yourName;

    public float duration = 10.0F;

    public Camera camera;
    public bool bg = false;
    public Color color1 = Color.green;
    public Color color2 = Color.blue;

    public GameObject sqareImage;
    public GameObject sqareImage2;
    public GameObject triImage;


    // Use this for initialization
    void Start () {

        sqareImage.SetActive(false);
        sqareImage2.SetActive(false);
        triImage.SetActive(false);

        coroutineStarted = false;
        yes = false;
        no = false;
        continueGame = false;

        yesno.SetActive(false);
//		bool change = true;
		tx = "  ";

		txt.text = " ";
        instructions.text = " ";
        gameover.text = " ";

        inputField.SetActive(false);
        //steps = 1;

        se = new InputField.SubmitEvent();
        se.AddListener(SubmitInput);
        input.onEndEdit = se;


        

		StartCoroutine("MyEvent");
	}
	
	// Update is called once per frame
	void Update () {

        //		changetext ();
        if (bg == true)
        {
           

            float p = Mathf.PingPong(Time.time, duration) / duration;
            camera.backgroundColor = Color.Lerp(color2, color1, p);

        }


        part.transform.Rotate(Vector3.up * Time.deltaTime);

		if (change == false && yes ==true) {

            bg = true;
            sqareImage.SetActive(false);
            sqareImage2.SetActive(false);
            instructions.text = "CONNECTING " + yourName + " TO THE PORTS";

			Rigidbody gameObjectsRigidBody = part.AddComponent<Rigidbody>();

			Invoke ("FreeFall", 8);

          



        }

       

        /*if (change == false && no == true){
			
			txt.text = "GAME OVER " + yourName;

			Invoke ("ChangeToYes",7);
			
			
		}*/

        if (continueGame ==true && Input.GetKeyDown(KeyCode.Joystick1Button3)){
            bg = true;
            instructions.text = "CONNECTING " + yourName + " TO THE PORTS";
            Invoke("FreeFall", 8);
        }



        if (Input.GetKeyDown(KeyCode.Joystick1Button1)){
            se = new InputField.SubmitEvent();
            se.AddListener(SubmitInput);
            input.onEndEdit = se;
        }







    }

	


	void ask (AudioClip aud) {


 
			GetComponent<AudioSource> ().PlayOneShot (aud);

	}


	private IEnumerator MyEvent()
	{
		if (change = true)
		{
			yield return new WaitForSeconds(3f); // wait half a second
			txt.text = " Welcome to the city of Nirgendheim";
            ask(welcome);
            //steps = 2;
            //change = !change;
            yield return new WaitForSeconds (4f);
			txt.text = "  ";
			yield return new WaitForSeconds(2f); // wait half a second
			txt.text = "I am your virtual Pet";
            ask(iampet);
            yield return new WaitForSeconds(3f);
            txt.text = "  ";

            yield return new WaitForSeconds(3f); // wait half a second
            txt.text = "I like to change my form";
            ask(changeform);
            yield return new WaitForSeconds(4f);
            txt.text = "  ";

            yield return new WaitForSeconds(2f); // wait half a second
            txt.text = "If you follow my instructions, one day it will all be yours";
            ask(followlead);
            yield return new WaitForSeconds (5f);
			txt.text = "  ";
            ask(willbeyours);
            yield return new WaitForSeconds (4f);
			ask (askname);
			txt.text = "What's your name?";
			yield return new WaitForSeconds (1f);
			txt.text = "  ";

			yield return new WaitForSeconds (3f);
			instructions.text = "THINK OF A NAME";

			yield return new WaitForSeconds (4f);
			txt.text = "   ";

            instructions.text = " ";

            yield return new WaitForSeconds (2f);
            inputField.SetActive(true);
            input.ActivateInputField();
            txt.text = "   ";
			ask (typename);
            instructions.text = " TYPE YOUR NAME";
            
			

			yield return new WaitForSeconds (5f);
			txt.text = "  ";
            instructions.text = " TO SUBMIT";
            sqareImage.SetActive(true);

            yield return new WaitForSeconds (8f);
            inputField.SetActive(false);
			ask (realname);
            sqareImage.SetActive(false);
            instructions.text = " ";

            yield return new WaitForSeconds (4f);
            yesno.SetActive(true);
            
            yield return new WaitForSeconds(2f);
            instructions.text = "USE ARROW KEYS TO SELECT YOUR ANSWER THEN           TO SUBMIT";
            sqareImage2.SetActive(true);
            

           

            
            // txt.text = " 'Y' or 'N' ";


            change = false;

            //change = !change;

           


		}
	}
    public IEnumerator OnGameOver()
    {
        if (no == true)
        {
           
            coroutineStarted = true;
            yield return new WaitForSeconds(1f);
            yesno.SetActive(false);
            gameover.text = "GAME OVER " + "\n" + yourName;
            instructions.text = yourName;
            sqareImage.SetActive(false);
            sqareImage2.SetActive(false);
            ask(notsure);

            yield return new WaitForSeconds(4f);

            txt.text = "  ";
            ask(attempt);
            continueGame = true;

            yield return new WaitForSeconds(4f);
            ask(continueif);
            instructions.text = " TO CONTINUE";
            triImage.SetActive(true);



        }
    }

         

	void FreeFall() {

		Application.LoadLevel ("ActIScene4");
	}

	private IEnumerator turnthree()
	{
		while(true)
		{
			yield return new WaitForSeconds(6f); // wait half a second
			txt.text = "think of a name";
			//steps = 3;
			
			
		}
	}

    public void SubmitInput (string arg0)
    {
        
        string currentText = txt.text;
        string newText = currentText + "\n" + arg0;
        txt.text = newText;
        //instructions.text = newText;
        yourName = newText;
        input.text = "";
        
    }

    public void ChangeYes()
    {
        yes = true;
    }


    public void ChangeNo()
    {
        no = true;
        if(coroutineStarted == false) { 
        StartCoroutine("OnGameOver");
        }
    }
}

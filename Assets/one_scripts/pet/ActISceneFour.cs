using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActISceneFour : MonoBehaviour {
    /// <summary>
    /// act I scene 4 optional
    /// this is where you ask if you want to play a game
    /// </summary>
    public GameObject inputField;
    public InputField input;
    InputField.SubmitEvent se;

    public static string sceneDesc;

    public GameObject parttwo;

	public AudioSource audio;

	public AudioClip spinning;

	public AudioClip where;

    public AudioClip trysomething;


    public Text txt;
    public Text infoText;
    public GameObject xImg;

    public string tx;
	
	//public GameObject cube;
	
	public bool change= true;
	public bool rotate = false;
	public bool rotateself = false;
	public bool bg = false;
    public bool camback = false;

    public bool ofcourse= false;
    public GameObject cam;

	public float duration = 10.0F;

	public Camera camera;

	public Color color1 = Color.green;
	public Color color2 = Color.blue;
	// Use this for initialization
	void Start () {

		camera = cam.GetComponent<Camera>();
		camera.clearFlags = CameraClearFlags.SolidColor;

		audio = GetComponent<AudioSource>();
		//		bool change = true;
		tx = "  ";
		
		txt.text = " ";
        infoText.text = " ";
        xImg.SetActive(false);

        inputField.SetActive(false);
        //steps = 1;

        se = new InputField.SubmitEvent();
        se.AddListener(SubmitInput);
        input.onEndEdit = se;
      

        StartCoroutine("MyEvent");
	}
	
	// Update is called once per frame
	void Update () {

		if (bg == true) {
            txt.text = sceneDesc;

			float p = Mathf.PingPong (Time.time, duration) / duration;
			camera.backgroundColor = Color.Lerp (color2, color1, p);
		
		}
		//		changetext ();
		
//		cube.transform.Rotate(Vector3.up * Time.deltaTime);
	
		parttwo.transform.Rotate(Vector3.right * Time.deltaTime);



		if ( rotate == true && Input.GetKey (KeyCode.Joystick1Button1)){
			

			cam.transform.Rotate (Vector3.left * Time.deltaTime *15);

			if (!audio.isPlaying){
			ask (spinning);
			}
		}

		if (rotateself == true) {

			cam.transform.Rotate (Vector3.left * Time.deltaTime * 25);

		}

        if (ofcourse == true && Input.GetKey(KeyCode.Joystick1Button1))
        {

            txt.text = " Of course you do ";
        }

        /*if (Input.GetKey(KeyCode.E)) {

			Application.LoadLevel ("allat1");
		}*/
        if (camback == true && Input.GetKey(KeyCode.Joystick1Button1)) ///touchpadra attenni
        {
            camLookBack(10F);
            
        }
        

    }
	
	void FixedUpdate() {
		
		
		
		//talk ();
	}

    void camLookBack ( float smooth)
    {
        Quaternion target = new Quaternion(0, 0, 0, 0);

        cam.transform.rotation = Quaternion.Slerp(transform.rotation, target , Time.deltaTime * smooth);
    }
	

	void ask (AudioClip aud) {

			audio.PlayOneShot (aud);
			//GetComponent<AudioSource> ().PlayOneShot (aud);

	}
	
	
	private IEnumerator MyEvent()
	{

	//	if (change = true)
		//{
			yield return new WaitForSeconds(5f); 
			infoText.text = "IF YOU'D LIKE TO CHANGE SOME OF THE PARAMETERS";
        xImg.SetActive(true);
			rotate = true;
        ofcourse = true;
        yield return new WaitForSeconds (6f);
        
        infoText.text = "   ";

        xImg.SetActive(false);

			yield return new WaitForSeconds (3f);
        ofcourse = false;
			txt.text = " But you don't have to ";

			yield return new WaitForSeconds (2f);

			txt.text = "   ";

			yield return new WaitForSeconds (3f);

			rotate = false;
			rotateself = true;

			yield return new WaitForSeconds (5f);


			ask (where);
       

			yield return new WaitForSeconds (2f);
        rotateself = false;
       infoText.text = "  YOUR PET MIGHT GET SLIGHTLY BORED ";
       

        yield return new WaitForSeconds (3f);
        ask(trysomething);
       infoText.text = "  ";



			yield return new WaitForSeconds (3f);

			infoText.text = " TRY TYPING SOMETHING SO YOUR PET WOULD KNOW YOU ARE STILL HERE";
        camback = true;
        inputField.SetActive(true);
        input.ActivateInputField();
        txt.text = "   ";

        yield return new WaitForSeconds (3f);

			txt.text = "  ";

        ask(where);

        yield return new WaitForSeconds (12f);

        inputField.SetActive(false);
        bg = true;

			yield return new WaitForSeconds (5f);
			
			Application.LoadLevel ("ActIScene5");

			change = false;
			
			//change = !change;
			
			
			
			
		//}
	}
	
	void FreeFall() {
		
		Application.LoadLevel ("ActIScene5");
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

    public void SubmitInput(string arg0)
    {
        string currentText = txt.text;
        string newText = currentText + "\n" + arg0;
        txt.text = newText;
        sceneDesc = newText;
       // input.text = "";
    }


}

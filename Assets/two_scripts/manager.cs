using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class manager : MonoBehaviour {

	//to restart the game
	public static bool resone;
	public static bool restwo;

	//change fence variables
	public static GameObject fenwhole;
	public static GameObject fenbroken;

    public static GameObject outputt;

    public static GameObject inputt;


    public static Text outputyours;

    public static string waterend;
    public static string fireend;



    /*//water temperature score on separate screens
	public static Text scoret;
	public static Text scoretw;
	
	public static float scoretemp;
	public static float scorewat;
	*/
    // Use this for initialization

    void Awake()
    {

       // outputyours = GameObject.Find("Canvas/output").GetComponent<Text>();
    }
    void Start () {
		/*Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 0)
            Display.displays[0].Activate();

        if (Display.displays.Length > 1)
			Display.displays[1].Activate();

        if (Display.displays.Length > 2)
            Display.displays[2].Activate();*/


        waterend= "January" + "\n" + "An image of the waterfalls." + "\n" + "You have found an object next to the border crossing. What is this object?" + "\n" + "An artifact pointing towards the future next to the customs booth at Roszke border crossing. Removed from the construction site of the fence with various other objects." + "\n" + "The fence is to be built before the beginning of the Summer. However it will be rebuilt several times later on" + "\n" + "As physical bodies are unwanted around the Zóna. As the Zóna does not require any physical bodies, their movement.";
        fireend = " August 27" + "\n" + " You are staring into the fire. " + "\n" + "It's either an artifact pointing towards the past or an aftermath of an event" + "\n" + "Your eyes are getting tired" +"\n"+ "3 pm, New Event: The riot has started." + " You are looking at a screen; a collection of scattered, oversaturated images" + "\n" + "freedom! the fence is broken" + "\n" + "police and military forces have been brought to the site. Transit zones declared." + "\n" + "New Event" + "\n" + " The reconstruction of the fence begins";

        fenwhole = GameObject.Find ("fenwhole");
		fenbroken = GameObject.Find ("fenbroken");

        outputt = GameObject.Find("Canvas/output");

        outputt.SetActive(false);

        inputt = GameObject.Find("Canvas/Input/InputField");

        inputt.SetActive(false);

       






        fenbroken.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

        if (resone == true && restwo == true)
        {
            Debug.Log("meg kene jelennie az outputnak");
            outputt.SetActive(true);
        }

        //if (Input.GetKeyDown("space"))
           


        if (Input.GetKey("escape"))

            Application.LoadLevel("startfar");
        //Application.Quit();

        }
   



    
}

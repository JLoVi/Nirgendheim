using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActISceneOne : MonoBehaviour {


    /// <summary>
    /// act one scene  one manager
    /// </summary>
	
	public GameObject parttwo;
	
	public AudioSource audio;
	
	public AudioClip spheres;
	
	public AudioClip fusion;

	public AudioClip blurred;

	public AudioClip eccel;

	public AudioClip hollow;

	public AudioClip larger;

	public AudioClip standing;

	public AudioClip reopen;
	
	
	public Text txt;
	
	public bool change= true;

	public bool gravity= false;

	public bool rotate = true;

	public GameObject cam;
	
	public float duration = 10.0F;
	
	public Camera camera;

	public float speed = 1.5f;

    private bool DPad = false;

    private bool reopenscene = false;


    

	void Start () {

        reopenscene = false;

		txt.text = " ";
		
		StartCoroutine("MyEvent");
	}
	
	// Update is called once per frame
	void Update () {
		
	
		if (rotate == true) {
			parttwo.transform.Rotate (Vector3.up * Time.deltaTime);
			parttwo.transform.Rotate (Vector3.left * Time.deltaTime);
		}
		
		if (gravity == true && Input.GetKey (GamepadController.instance.controlList.spaceTimeControl)) {

            Debug.Log("WHY ARENt you falling");
			rotate = false;
			
			parttwo.AddComponent<Rigidbody> ();

		}

		if (reopenscene == true && Input.GetKey(GamepadController.instance.controlList.closeReopenControl)){

            SceneManager.LoadScene("ActIScene2");
		}

        
         if (DPad==true){
            //parttwo.transform.Translate(Input.GetAxis("PS4_DPadHorizontal") * Time.deltaTime, Input.GetAxis("PS4_DPadVertical") * Time.deltaTime, 0f);
            parttwo.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, Input.GetAxis("Vertical") * Time.deltaTime, 0f);


        }

    }
	
	
	
	void Ask (AudioClip aud) {
		
		audio.PlayOneShot (aud);
	
		
	}
	
	
	private IEnumerator MyEvent()
	{
		
		if (change)
		{

           // DPad = true;

            yield return new WaitForSeconds (1f);
			txt.text = " LISTEN ";
		

			yield return new WaitForSeconds (3f);
			
			txt.text = "   ";
			
			yield return new WaitForSeconds (1f);
            Ask(spheres);
            //	ask (fusion);

            yield return new WaitForSeconds (15f);
			
            string s = string.Format("USE <color=#00ff00ff>{0}</color> TO CONTROL THE FREE FALL PARAMETERS", GamepadController.instance.controlList.dPadName);
            txt.text = s;

            DPad = true;

            yield return new WaitForSeconds (6f);

            //	ask (blurred);

            txt.text = "YOUR PET MIGHT GET A LITTLE BORED"; //do something?
            yield return new WaitForSeconds (15f);

            //	ask (eccel);
            //			ask (where); 

            txt.text = "  ";

            yield return new WaitForSeconds (10f);
            txt.text = "BE PATIENT"; //do something?



            yield return new WaitForSeconds (5f);
            //	ask (larger);
            txt.text = "YOU'RE LEARNING";

            yield return new WaitForSeconds(7f);

            txt.text = " ";

            yield return new WaitForSeconds(5f);

            gravity = true;

            string t = string.Format("USE <color=#00ff00ff>{0}</color> TO TWEAK SPACE-TIME PARAMETERS", GamepadController.instance.controlList.spaceTimeName);
            txt.text = t;

            gravity = true;

			yield return new WaitForSeconds (6f);

            //ask (standing);
            Ask(hollow);

            txt.text = "   ";
           

            yield return new WaitForSeconds (5f);

			txt.text = "YOUR PET DROPPED YOUR PHONE"; //do something?
            // here change animation

			yield return new WaitForSeconds (5f);

		//	ask (standing);

			txt.text = "   ";

			yield return new WaitForSeconds (18f);
			
			Ask (reopen);

			yield return new WaitForSeconds (4f);
            reopenscene = true;

            string ct = string.Format("USE <color=#00ff00ff>{0}</color> TO CLOSE, REOPEN", GamepadController.instance.controlList.closeReopenName);
            txt.text = ct;
            
           
			
			change = false;
			
		
		}
	}
	
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ActISceneTwo : MonoBehaviour {
    /// <summary>
    /// act I scene two
    /// </summary>

	public GameObject body1;

	public GameObject body2; 

	public GameObject parttwo;
	
	public AudioSource audio;
	
	public AudioClip chasm;

	public AudioClip bodyd;

	public AudioClip bodyc;

	public AudioClip newobj;

    public AudioClip idInstruction;

    public AudioClip enterZona;

    public bool change= true;

	public bool del= false;

	public bool add= false;

	public Text txt;
    public Text iDnumdisplay;

	public Text pos;

	public bool noesc= false;

	public bool stopz = true;

	public float Ye;

	public string yy;

	public int adj;


    //ID

    public static float iDNum;
	// Use this for initialization
	void Start () {
     

        body2.SetActive (false);
		
		txt.text = " ";
		pos.text = " ";
        iDnumdisplay.text = " ";
		//steps = 1;
		
		StartCoroutine("MyEvent");
	}
	
	// Update is called once per frame
	void Update () {

		Ye = parttwo.transform.position.y;


		if (stopz == true) {
			pos.text = "X: " + parttwo.transform.position.x + "   Y: 0 " + "  Z: " + parttwo.transform.position.y;

		}

		if (del == true && Input.GetKey (GamepadController.instance.controlList.deleteBodyControl)) {

			body1.SetActive (false);

		}


		if (add == true && Input.GetKey (GamepadController.instance.controlList.addBodyControl)) {

			body2.SetActive (true);

			adj = 45;
			body2.transform.position = new Vector3 (body2.transform.position.x, parttwo.transform.position.y-adj, body2.transform.position.z);

            iDNum = Mathf.Abs(parttwo.transform.position.y)*100000;
            iDnumdisplay.text = "ID: " +iDNum;
            


        }

		if (noesc == true && Input.GetKey (GamepadController.instance.controlList.meetPetControl)) {

			stopz = true;

			StopAllCoroutines();


            SceneManager.LoadScene("actIScene3");

        }
	
	}


	void ask (AudioClip aud) {
		
		audio.PlayOneShot (aud);
		//GetComponent<AudioSource> ().PlayOneShot (aud);
		
	}

	private IEnumerator MyEvent()
	{
		
		if (change = true)
		{
			yield return new WaitForSeconds (2f);
			
			ask (chasm);
			
			yield return new WaitForSeconds (25f);

			ask (bodyd);

			yield return new WaitForSeconds (2f);

			del = true;
			
			txt.text = "  ";

			yield return new WaitForSeconds (1f);

			

            string s = string.Format("USE <color=#00ff00ff>{0}</color> TO DELETE THE BODY", GamepadController.instance.controlList.deleteBodyName);
            txt.text = s;


            yield return new WaitForSeconds (5f);
			ask (newobj);
			txt.text = "  ";

           
         

            add = true;

			yield return new WaitForSeconds (9f);
			
			ask (bodyc);

			yield return new WaitForSeconds (2f);
		

            s = string.Format("USE <color=#00ff00ff>{0}</color> TO ADD A BODY", GamepadController.instance.controlList.addBodyName);
            txt.text = s;

            yield return new WaitForSeconds (5f);

			txt.text = "  ";

          
           

            yield return new WaitForSeconds (10f);

			txt.text = " REMEMBER YOUR ID ";
            ask(idInstruction);
            stopz = false;

			//stop distance thingy
			yield return new WaitForSeconds (5f);
			
			txt.text = "  ";

			yield return new WaitForSeconds (4f);
			
			txt.text = " YOUR PET WILL MISS YOU ";
            ask(enterZona);

            yield return new WaitForSeconds (6f);
			
            s = string.Format("PRESS <color=#00ff00ff>{0}</color> TO MEET YOUR PET BEFORE YOU CONTINUE", GamepadController.instance.controlList.meetPetName);
            txt.text = s;
            noesc = true;


            yield return new WaitForSeconds (6f);
			
			txt.text = " ";
          

            yield return new WaitForSeconds (6f);

            //your pet is unhappy if you dont stay so this loads the unhappy scene before entering the zona. you didn't want to play so your pet is unhappy now.

         
            SceneManager.LoadScene("act II");

            change = false;
			
			//change = !change;
			
			
			
			
		}
	}
}

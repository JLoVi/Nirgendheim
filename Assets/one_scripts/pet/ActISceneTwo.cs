using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    public GameObject oImage;

    public GameObject xImage;

    public GameObject triImage;

    




    //ID

    public static float iDNum;
	// Use this for initialization
	void Start () {
        oImage.SetActive(false);
        xImage.SetActive(false);
        triImage.SetActive(false);

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

		if (del == true && Input.GetKey (KeyCode.Joystick1Button1)) {

			body1.SetActive (false);


		}


		if (add == true && Input.GetKey (KeyCode.Joystick1Button2)) {

			body2.SetActive (true);

			adj = 45;
			body2.transform.position = new Vector3 (body2.transform.position.x, parttwo.transform.position.y-adj, body2.transform.position.z);

            iDNum = Mathf.Abs(parttwo.transform.position.y)*100000;
            iDnumdisplay.text = "ID: " +iDNum;
            

            


        }

		if (noesc == true && Input.GetKey (KeyCode.Joystick1Button3)) {

			stopz = true;

			StopAllCoroutines();

            Application.LoadLevel("actIScene3");
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

			txt.text = "TO DELETE THE BODY ";
       
            xImage.SetActive(true);


            yield return new WaitForSeconds (5f);
			ask (newobj);
			txt.text = "  ";

           
            xImage.SetActive(false);

            add = true;

			yield return new WaitForSeconds (9f);
			
			ask (bodyc);

			yield return new WaitForSeconds (2f);
				txt.text = "TO ADD A BODY ";

            oImage.SetActive(true);
            
            yield return new WaitForSeconds (5f);

			txt.text = "  ";

            oImage.SetActive(false);
           

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

            yield return new WaitForSeconds (5f);
			
			txt.text = "TO MEET YOUR PET BEFORE YOU CONTINUE";
            noesc = true;

            triImage.SetActive(true);

            yield return new WaitForSeconds (4f);
			
			txt.text = " ";
            triImage.SetActive(false);


            yield return new WaitForSeconds (8f);

            //your pet is unhappy if you dont stay so this loads the unhappy scene before entering the zona. you didn't want to play so your pet is unhappy now.

            Application.LoadLevel("act II"); //azutan majd zona kell

            change = false;
			
			//change = !change;
			
			
			
			
		}
	}
}

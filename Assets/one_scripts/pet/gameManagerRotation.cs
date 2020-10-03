using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManagerRotation : MonoBehaviour {

    /// <summary>
    /// this will be the happy script act I scene 5 optional. need unhappy too
    /// this happens if you say yes to the game. you enter zona
    /// unhappy optional freefall allat3
    /// </summary>
    public AudioSource audio;



    public AudioClip rotation;

    public AudioClip enterrZona;
    public Text txt;

	public bool change= true;
	//public GameObject cam;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        StartCoroutine("MyEvent");
	}
	
	// Update is called once per frame
	void Update () {
		//cam.transform.Rotate(Vector3.up * Time.deltaTime);

		/*if (change == false && Input.GetKey (KeyCode.Joystick1Button1)) {
			
			txt.text = "yes";
			
			Invoke ("FreeFall", 3);
			
		}*/
	}

	private IEnumerator MyEvent()
	{
		
		if (change = true) {

			
			yield return new WaitForSeconds (2f);
            ask(rotation);
			

			yield return new WaitForSeconds (10f);

            txt.text = "  ";

            yield return new WaitForSeconds (2f);
           
			

            yield return new WaitForSeconds(12f);
            Application.LoadLevel("act II");

            change = false;

		
			
		}

	}

			void FreeFall() {
				
				Application.LoadLevel ("seconddialogue");
			}
    void ask(AudioClip aud)
    {

        audio.PlayOneShot(aud);
        //GetComponent<AudioSource> ().PlayOneShot (aud);

    }



}

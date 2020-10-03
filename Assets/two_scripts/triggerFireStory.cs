using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class triggerFireStory : MonoBehaviour {
	public GameObject[] fireroom;

    public AudioClip[] otherClip;

    public AudioSource audio;

    public static int storyWater;

	public Text felirat;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();

        manager.resone = false;
		storyWater = 0;
		/*foreach(GameObject wi in fireroom) {
			wi.SetActive(false);
		} */
	}
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log(storyWater +" firelevel");
    }

	void OnTriggerEnter(){

		storyWater += 1;
		Debug.Log (storyWater);

		Story ();
	}

	void OnTriggerExit (){
		felirat.text = " ";
	}



	void Story()
	{
		switch (storyWater)
		{
		case 1:

                
                felirat.text= " August 27" + "\n" + " You are staring into the fire. ";
			//fireroom[0].SetActive(true);
                audio.clip = otherClip[0];
                audio.Play();
                break;
		case 2:
			felirat.text =  "Either an artifact pointing towards the past ";
               // fireroom[1].SetActive(true);
                audio.clip = otherClip[1];
                audio.Play();
                break;
		case 3:
			felirat.text = "or an aftermath of an event";
               // fireroom[2].SetActive(true);
                
                audio.clip = otherClip[2];
                audio.Play();
                break;
		case 4:
			felirat.text = "You are looking at a screen: scattered, oversaturated images";
             //   fireroom[3].SetActive(true);
                
                audio.clip = otherClip[3];
                audio.Play();
                break;
		case 5:
                felirat.text = "3 pm, New Event: The riot has started.";
                //fireroom[4].SetActive(true);
                
                audio.clip = otherClip[4];
                audio.Play();
                break;
		case 6:
			felirat.text = "freedom! the fence is broken" ;
              //  fireroom[5].SetActive(true);
                
                audio.clip = otherClip[5];
                audio.Play();
                break;
		case 7:
			felirat.text = "police and military forces have been brought to the site";
             //   fireroom[6].SetActive(true);
                
                audio.clip = otherClip[6];
                audio.Play();
                break;
		case 8:
			felirat.text = "Your eyes are getting tired";
               // fireroom[7].SetActive(true);
                
                audio.clip = otherClip[7];
                audio.Play();
                break;
		case 9:
			felirat.text = "New event: Transit zones declared.";
		//	fireroom[8].SetActive(true);
               
                audio.clip = otherClip[8];
                audio.Play();
                break;
		case 10:
                felirat.text =  "New Event: The reconstruction of the fence begins";

              //  fireroom[9].SetActive(true);
               
                audio.clip = otherClip[9];
                audio.Play();
                break;

		case 11:

            felirat.text = " ";
            manager.resone = true;
			Debug.Log(manager.resone  + "fireover");
			break;

		default:
			felirat.text = "  ";

			break;
		}
	}
}

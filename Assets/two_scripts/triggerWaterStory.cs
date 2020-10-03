using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class triggerWaterStory : MonoBehaviour {


	public GameObject[] waterroom;

	public static int storyFire;
	
	public Text felirat;

    public AudioClip[] otherClipwater;

    public AudioSource audiowater;

    // Use this for initialization
    void Start () {
        audiowater = GetComponent<AudioSource>();

        manager.restwo = false;
		storyFire = 0;
		/*foreach(GameObject wi in waterroom) {
			wi.SetActive(false);
		} */
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(storyFire + "waterlevel");
	}
	
	void OnTriggerEnter(){
		
		storyFire += 1;
		//Debug.Log (storyFire);
		
		Story ();
	}
	
	void OnTriggerExit (){
		felirat.text = " ";
	}
	
	
	void Story()
	{

       //if approached first (without card write "something is wrong with the vending machine have a look around to find some clues [x]") if you have the card start the switch below
		switch (storyFire)
		{
            case 1:
			felirat.text= " January."  + "\n" + "An image of the waterfalls.";

           // waterroom [0].SetActive(true);
                audiowater.clip = otherClipwater[0];
                audiowater.Play();
                break;

        case 2:
                felirat.text = "You have found an object next to the border crossing." + "\n" +  "What is this object?";

          //  waterroom[1].SetActive(true);
                audiowater.clip = otherClipwater[1];
                audiowater.Play();
                break;

        case 3:
			felirat.text = "An artifact pointing towards the future.";
			//waterroom [2].SetActive(true);
                audiowater.clip = otherClipwater[2];
                audiowater.Play();
                break;

		case 4:
			felirat.text = "A dismantled water vending machine. What a coincidence." + "\n" +  "Maybe a water shortage is being planned.";
			//waterroom [3].SetActive(true);
                audiowater.clip = otherClipwater[3];
                audiowater.Play();
                break;
		case 5:
			felirat.text = "next to the customs booth at Roszke border crossing.";
		//	waterroom [4].SetActive(true);
                audiowater.clip = otherClipwater[4];
                audiowater.Play();
                break;
		case 6:
			felirat.text = "removed from the construction site of the fence ";
			//waterroom [5].SetActive(true);
                audiowater.clip = otherClipwater[5];
                audiowater.Play();
                break;
		case 7:
			felirat.text = "with various other objects";
		//	waterroom [6].SetActive(true);
                audiowater.clip = otherClipwater[6];
                audiowater.Play();
                break;
		case 8:
			felirat.text = "The fence is to be built before the beginning of the Summer.";
			//waterroom [7].SetActive(true);
                audiowater.clip = otherClipwater[7];
                audiowater.Play();
                break;

        case 9:
                felirat.text = "It will be rebuilt several times later on";

         //   waterroom[8].SetActive(true);
                audiowater.clip = otherClipwater[8];
                audiowater.Play();
                break;
        case 10:
                felirat.text = "As the Zóna does not require physical bodies.";

             //   waterroom[9].SetActive(true);
                audiowater.clip = otherClipwater[9];
                audiowater.Play();
                break;

        case 11:

            felirat.text = " ";
   			manager.restwo = true;
                Debug.Log("waterover");
			break;

		default:
			felirat.text = "  ";
			break;
		}
	}
	
}

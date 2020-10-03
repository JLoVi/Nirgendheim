using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//CHANGES SCORE OF TEMPERATURE
public class score : MonoBehaviour {
	public bool bef;
	public Text scoret;
	public Text scoretw;

    public Text warningw;

	public float scoretemp;
	public float scorewat;

    public GameObject worldcol;

	// Use this for initialization
	void Start () {
		scoretemp = 60;
		scorewat = 50;
	}
	
	// Update is called once per frame
	void Update () {

		if (bef == true) {

            worldcol.SetActive(false);

			scoretemp += Time.deltaTime / 4;

            scorewat -= Time.deltaTime / 4;

            if (scoretemp < 100 && scoretemp > 15) {
	 
				scoret.text = "TEMPERATURE  " + (int)scoretemp + " %";
                warningw.text = " ";
            }

            if (manager.resone == true)
            {
                scoret.text = manager.fireend;
            }



            else if (scorewat > 15) {
			
				scoretw.text = "WATER  " + (int)scorewat + " %";
                warningw.text = " ";


            }

           

            else if (scorewat < 1)
            {
                scoretw.text = "WATER  " + 00 + " %" + "\n" + manager.waterend;

                warningw.text = "your water levels are too low to continue." + "\n" + "Press ESCAPE to restart";

                scoretw.text = manager.waterend;
            }

           else if (scoretemp < 1)
            {

                scoret.text = "TEMPERATURE  " + 00 + " %" + "\n" + manager.fireend;

                warningw.text = "the temperature is too low to continue." + "\n" + "Press ESCAPE to restart";
            }

            else if (scoretemp < 15)
            {

                scoret.text = "TEMPERATURE  " + (int)scoretemp + " %" + "\n" + " The temperature is getting very low";

                warningw.text = " The temperature is getting very low";
            }

            

            else if (scorewat < 15)
            {

                scoretw.text = "WATER  " + (int)scorewat + " %" + "\n" + " You are running out of water, get some water from the vending machine at the station on the other side of the fence";

                warningw.text = " You are running out of water";
            }


           



        }

       

       
       
	}

	void OnTriggerEnter()
	{


		bef = true;
		Debug.Log ("enter");
		Debug.Log (bef);
	}

	void OnTriggerExit () {

		bef = false;
	}
	 

}

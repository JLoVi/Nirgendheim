using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class firedialogue : MonoBehaviour {


    public GameObject FireButton;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

       

    }

    void OnTriggerEnter()
    {
        FireButton.SetActive(true);
    }

    public void UpdateCurrentPanel(string panelName)
    {
        foreach (Transform child in transform)
        {
            if (child.name == panelName)
            {
                child.gameObject.SetActive(true);
            }

            else
                child.gameObject.SetActive(false);
        }

    }
}

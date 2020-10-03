using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clickedobj : MonoBehaviour {

    public GameObject buttonone;

    public static bool click;

    
    // Use this for initialization
    void Start () {

        click = false;
        buttonone.SetActive(false);
}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        click = true;

        if (buttonone.activeSelf == false) { 
        buttonone.SetActive(true);
        }

        Debug.Log("click" + click);
    }

    public void TurnOff()
    {
        buttonone.SetActive(false);
    }
}

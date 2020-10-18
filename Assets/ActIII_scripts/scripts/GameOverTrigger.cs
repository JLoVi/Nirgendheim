using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour {


    public GameObject gameOverCanvas;
    public Text gameOverMessage;
    public bool activated;


	// Use this for initialization
	void Start () {
        gameOverCanvas.SetActive(false);
        activated = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (activated && Input.GetKey(GamepadController.instance.controlList.submitControl)){
            RestartNirgendheim();
        }
	
	}

    void OnTriggerEnter()
    {
        gameOverCanvas.SetActive(true);
        activated = true;
        string s = string.Format("THIS PLACE IS WEIRD. YOUR PET THINKS THERE'S ONLY ONE WAY DOWN. Press <color=#00ff00ff>{0}</color> to enter FREE FALL", GamepadController.instance.controlList.submitName);
        gameOverMessage.text = s;
        
    }


    public void RestartNirgendheim()
    {
       // Application.LoadLevel("act I");
        SceneManager.LoadScene("act I");
    }

}

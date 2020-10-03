using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverTrigger : MonoBehaviour {


    public GameObject gameOverCanvas;


	// Use this for initialization
	void Start () {
        gameOverCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        gameOverCanvas.SetActive(true);
    }


    public void RestartNirgendheim()
    {
        Application.LoadLevel("act I");
    }

}

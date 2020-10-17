using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadAct3 : MonoBehaviour {

    void OnTriggerEnter()
    {
      //  Application.LoadLevel("ACT III");
        SceneManager.LoadScene("ACT III");
    }
}

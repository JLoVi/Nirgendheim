using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NirgenManager : MonoBehaviour
{

    public GameObject pausePanel;

    public GameObject simapanel;

    public ControlList controlList;

    public bool isPaused;

    public static string idNumber;

    void Start()
    {

        isPaused = false;

        pausePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       

        if (isPaused)
        {
            PauseGame(true);
        }
        else
        {
            PauseGame(false);
        }

        if (Input.GetKeyDown(controlList.mainMenuInputMAC) ||
            Input.GetKeyDown(controlList.mainMenuInputPC))
            {
            
                SwitchPause();
            }
    }

    void PauseGame(bool state)
    {
        if (state)
        {

            Time.timeScale = 0.1f; //paused
        }

        else
        {
            Time.timeScale = 1.0f; //unpaused
        }

        pausePanel.SetActive(state);
        simapanel.SetActive(!state);
    }

    public void SwitchPause()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }
}



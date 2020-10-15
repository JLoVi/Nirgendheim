using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectedButtonActions : MonoBehaviour, ISelectHandler // required interface for OnSelect
{

    public string sceneToLoad;



    //Do this when the selectable UI object is selected.
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");

        if(Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick1Button2)|| Input.GetKey(KeyCode.Joystick1Button18))
        {
            Debug.Log("jjjjj");
        }
    }

   
    public void LoadAct()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TextInput : MonoBehaviour {


    InputField input;
    InputField.SubmitEvent se;
    public Text output;
	

    
	void Start () {

       
        input = gameObject.GetComponent<InputField>();
        se = new InputField.SubmitEvent();
        se.AddListener(Submitinput);
        input.onEndEdit = se; 
	
	}

    private void Submitinput(string arg0)
    {
        string currentText = output.text; //.ToString();
        string newText = currentText + "\n" + arg0;
        output.text = newText;
        input.text = "";
        input.ActivateInputField();
    }
}

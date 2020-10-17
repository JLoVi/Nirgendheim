using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;
    
    public int startLine;
    public int endLine;

    public DialogueManager dialogueBoxManager;


    public bool DestroyWhenActivated;

	// Use this for initialization
	void Start () {
        dialogueBoxManager = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController") {
            dialogueBoxManager.ReloadScript(theText);
            dialogueBoxManager.currentLine = startLine;
            dialogueBoxManager.endAtLine = endLine;
            dialogueBoxManager.EnableTextBox();

                }
        if (DestroyWhenActivated)
        {
            Destroy(gameObject);
        }
    }
    
}

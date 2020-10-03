using UnityEngine;
using System.Collections;

public class soundTrigger : MonoBehaviour {

    private bool hasPlayed = false;

    public AudioSource audio;

    public AudioClip storyNarration;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        if (!hasPlayed)
        {
            audio.PlayOneShot(storyNarration);
            hasPlayed = true;
            
        }
    }
}

using UnityEngine;
using System.Collections;

public class MovingLift : MonoBehaviour {


    public Transform movingPlatform;
  
    
   
    public float smooth;

    public GameObject secondPlayer;

    public GameObject newPlayer;

  

   


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
       
	}

    //if the fps drops this fixes
   

    void OnTriggerEnter()
    {
        Invoke("destroyStuff", 15);
    }

    void destroyStuff()
    {
        if (secondPlayer != null && secondPlayer.activeSelf ==true) { 
        secondPlayer.SetActive(false);
        }
        if (movingPlatform != null) { 
        Destroy(movingPlatform.gameObject);
        }

        newPlayer.SetActive(true);
    }
}

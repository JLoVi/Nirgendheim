using UnityEngine;
using System.Collections;

public class MovingLift : MonoBehaviour
{


    public Transform movingPlatform;



  //  public float smooth;

    public GameObject roamPlayer;

    public GameObject cryonixPlayer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    //if the fps drops this fixes


    void OnTriggerEnter()
    {
        Invoke("SetPlayers", 20);
        Invoke("DestroyStuff", 25);
    }

    void DestroyStuff()
    {
        // if (secondPlayer != null && secondPlayer.activeSelf ==true) { 
        // secondPlayer.SetActive(false);
        //   }
        if (movingPlatform != null)
        {
            Destroy(movingPlatform.gameObject);
        }


    }

    void SetPlayers()
    {
        cryonixPlayer.SetActive(true);
        roamPlayer.SetActive(false);

    }
}

using UnityEngine;
using System.Collections;

public class ChangePlayerPos : MonoBehaviour {

    public GameObject camtoDestroy;
    public GameObject camOriginalPos;
    public GameObject player;

    public GameObject destination;

    public GameObject canvasToActivate;

    public GameManager canvasManager;

    // Use this for initialization
    void Start () {
        canvasManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider cam)
    {
        if (cam = camtoDestroy.GetComponent<BoxCollider>()) { 
        // cam = camtoDestroy.GetComponent<Camera>();
            player.SetActive(true);

            Destroy(camtoDestroy.GetComponent<Rigidbody>());
            camtoDestroy.transform.position = camOriginalPos.transform.position;
            camtoDestroy.SetActive(false);
            foreach (GameObject canv in canvasManager.canvases)
            {
                canv.SetActive(false);
            }

            // player.transform.position = destination.transform.position;

            canvasToActivate.SetActive(true);
           

        }

        //camtoDestroy.transform.position = camOriginalPos.transform.position;
        // camtoDestroy.SetActive(false);

    }
}

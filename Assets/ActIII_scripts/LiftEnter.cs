using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LiftEnter : MonoBehaviour {

    public AudioSource ambienceOne;
    public AudioSource ambienceTwo;
    public AudioSource audiooo;
    public float fadeSpeed = 5f;
    float time = 0f;

    public AudioClip oneDay;

    public Transform movingPlatform;
    public Transform position1;
    public Transform position2;
    public Vector3 newPosition;
   
    public float smooth;


    public bool enteredLift;

    public GameObject FirstPlayer;

    public GameObject secondNewPlayer;

    public bool hasStarted;

    public Text infoView;

    public GameObject canvasesLent;


    public GameManager canvasManager;


    // Use this for initialization
    void Start()
    {
        canvasManager=FindObjectOfType<GameManager>();

        hasStarted = false;
        enteredLift = false;
        secondNewPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }

    //if the fps drops this fixes
    void FixedUpdate()
    {
        //

        if (enteredLift && movingPlatform != null ) {
            movingPlatform.position = Vector3.Lerp(movingPlatform.position, position2.position, smooth * Time.deltaTime);

            foreach (GameObject canv in canvasManager.canvases)
            {
                canv.SetActive(false);
            }



        }
    }

    void OnTriggerEnter()
    {
        enteredLift = true;
        Debug.Log(enteredLift+"enteredlift");
        if (FirstPlayer.activeSelf ==true){ 
        FirstPlayer.SetActive(false);
        }
        if(secondNewPlayer.activeSelf == false) { 
            secondNewPlayer.SetActive(true);

           
        }
        infoView.text = " Target: the View";
        audiooo.PlayOneShot(oneDay);
        ambienceOne.volume = Mathf.Lerp(1f, 0f, time);
        time += Time.deltaTime / fadeSpeed;
        ambienceOne.volume = 0;

        StartCoroutine("FadeInSound");


        // Destroy(gameObject);

    }
    IEnumerator FadeInSound()
    {
        //yield return new WaitForSeconds(1f);
        /*txt.text = "Press [x] if you'd like to change some of the parameters.";
        rotate = true;
        ofcourse = true;*/
        float startVolume = 0.1f;

        while (ambienceTwo.volume < 1)
        {
            ambienceTwo.volume += startVolume * Time.deltaTime / 3;

            yield return null;
        }
    }

   



}
